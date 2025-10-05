using System;
using System.Collections.Generic;
using UnityEditor;

public enum StateType
{
    Idle,
    Run,
    Attack,
    Jump,
}

public abstract class State
{
    protected BaseStateMachine stateMachine;

    protected RoleEntity roleEntity;

    public State(BaseStateMachine stateMachine, RoleEntity roleEntity)
    {
        this.stateMachine = stateMachine;
        this.roleEntity = roleEntity; 
    }

    public abstract void Enter();
    public abstract void Update(float deltaTime);
    public abstract void Exit();
}

public class BaseStateMachine { 
}


public class StateMachine : BaseStateMachine
{
    private State currentState;
    private Dictionary<StateType, State> states = new Dictionary<StateType, State>();

    public StateType CurrentStateType { get; private set; }

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
            if(CurrentStateType == newStateType)
            {
                return;
            }
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
        // 状态自身逻辑
        if (currentState != null)
        {
            currentState.Update(deltaTime);
        }
    }

    public void Destroy()
    {

    }
}
