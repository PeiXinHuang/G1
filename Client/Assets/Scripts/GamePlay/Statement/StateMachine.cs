using System;
using System.Collections.Generic;

public enum StateType
{
    Idle,
    Run,
    Attack,
    Jump,
}

public abstract class State
{
    protected StateMachine stateMachine;

    protected RoleEntity roleEntity;

    public State(StateMachine stateMachine, RoleEntity roleEntity)
    {
        this.stateMachine = stateMachine;
        this.roleEntity = roleEntity; 
    }

    public virtual void Enter() { }
    public virtual void Update(float deltaTime) { }
    public virtual void Exit() { }
}

public class StateMachine
{
    private State currentState;
    private Dictionary<StateType, State> states = new Dictionary<StateType, State>();

    public StateType CurrentStateType { get; private set; }

    // 条件切换逻辑：允许注册条件切换，Update时自动检测并切换
    private Dictionary<StateType, List<Func<bool>>> transitionConditions = new Dictionary<StateType, List<Func<bool>>>();

    public void AddState(StateType type, State state)
    {
        if (!states.ContainsKey(type))
        {
            states[type] = state;
        }
    }

    public void ChangeState(StateType newStateType)
    {
        if (states.ContainsKey(newStateType))
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = states[newStateType];
            CurrentStateType = newStateType;
            currentState.Enter();
        }
    }

    public void Update(float deltaTime)
    {
        // 检查条件切换
        if (transitionConditions.ContainsKey(CurrentStateType))
        {
            foreach (var cond in transitionConditions[CurrentStateType])
            {
                if (cond())
                {
                    // 条件满足并已切换状态，跳出
                    break;
                }
            }
        }
        // 状态自身逻辑
        if (currentState != null)
        {
            currentState.Update(deltaTime);
        }
    }

    public void Destroy()
    {

    }
    

    /// <summary>
    /// 注册从当前状态到目标状态的切换条件
    /// </summary>
    public void AddTransition(StateType from, StateType to, Func<bool> condition)
    {
        if (!transitionConditions.ContainsKey(from))
        {
            transitionConditions[from] = new List<Func<bool>>();
        }
        // 包装条件，使其在满足时切换到目标状态
        transitionConditions[from].Add(() =>
        {
            if (condition())
            {
                ChangeState(to);
                return true;
            }
            return false;
        });
    }
}
