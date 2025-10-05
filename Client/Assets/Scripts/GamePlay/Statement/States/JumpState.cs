using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public enum JumpSubStateType
{
    Start,
    Peak,
    Land
}
public class JumpState : State
{
    private JumpStateMachine jumpSubStateMachine;
    public JumpState(StateMachine stateMachine, RoleEntity roleEntity) :
        base(stateMachine, roleEntity)
    {
        jumpSubStateMachine = new JumpStateMachine();
        jumpSubStateMachine.AddState(JumpSubStateType.Start, new JumpStartState(jumpSubStateMachine, roleEntity));
        jumpSubStateMachine.AddState(JumpSubStateType.Peak, new JumpPeakState(jumpSubStateMachine, roleEntity));
        jumpSubStateMachine.AddState(JumpSubStateType.Land, new JumpLandState(jumpSubStateMachine, roleEntity));
    }

    public override void Enter()
    {
        this.roleEntity.PlayAnim(AnimationName.Jump);
        //if(this.roleEntity.IsOnGround())
        //    this.jumpSubStateMachine.ChangeState(JumpSubStateType.Start);
        //else
        //    this.jumpSubStateMachine.ChangeState(JumpSubStateType.Peak);
    }

    public override void Update(float deltaTime)
    {
        //jumpSubStateMachine.Update(deltaTime);
    }

    public override void Exit()
    {
    }
}

public class JumpStateMachine : BaseStateMachine {
    private State currentState;
    private Dictionary<JumpSubStateType, State> states = new Dictionary<JumpSubStateType, State>();

    public JumpSubStateType CurrentStateType { get; private set; }
    public void AddState(JumpSubStateType stateType, State state)
    {
        if (!states.ContainsKey(stateType))
        {
            states[stateType] = state;
        }
    }

    public void ChangeState(JumpSubStateType newStateType)
    {
        if (states.ContainsKey(newStateType))
        {
            if (CurrentStateType == newStateType)
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
        // ״̬�����߼�
        if (currentState != null)
        {
            currentState.Update(deltaTime);
        }
    }

    public void Destroy()
    {

    }

}


// ����Ϊ����״̬ʵ��ʾ��
public class JumpStartState : State
{
    public JumpStartState(JumpStateMachine stateMachine, RoleEntity roleEntity)
        : base(stateMachine, roleEntity) { }

    public override void Enter()
    {
        // ������������Ч
    }

    public override void Update(float deltaTime)
    {
        // ����Ƿ���������׶�
    }

    public override void Exit()
    {
        
    }
}


public class JumpPeakState : State
{
    public JumpPeakState(JumpStateMachine stateMachine, RoleEntity roleEntity)
       : base(stateMachine, roleEntity) { }

    public override void Enter()
    {
        // ������������Ч
    }

    public override void Update(float deltaTime)
    {
        // ����Ƿ���������׶�
    }

    public override void Exit()
    {

    }
}

public class JumpLandState : State
{
    public JumpLandState(JumpStateMachine stateMachine, RoleEntity roleEntity)
        : base(stateMachine, roleEntity) { }

    public override void Enter()
    {
        // ��ض�������Ч
    }

    public override void Update(float deltaTime)
    {
        //// ����Ƿ���������׶�
        //stateMachine.ChangeState(JumpSubStateType.Ascend);
    }

    public override void Exit()
    {

    }
}