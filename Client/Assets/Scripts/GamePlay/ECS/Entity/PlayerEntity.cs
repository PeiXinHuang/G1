using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEntity : RoleEntity
{
    private PlayerCtrl playerCtrl;
    public PlayerEntity() : base()
    {
        stateMachine.AddState(StateType.Idle, new IdleState(stateMachine, this));
        stateMachine.AddState(StateType.Run, new MoveState(stateMachine, this));
        stateMachine.AddState(StateType.Jump, new JumpState(stateMachine, this));
        stateMachine.AddState(StateType.Attack, new AttackState(stateMachine, this));
        stateMachine.ChangeState(StateType.Idle);

        // Wrap the method call in a lambda to match the expected Func<bool> delegate type
        //stateMachine.AddTransition(StateType.Idle, StateType.Run, () => StateFuncUtils.IsTranslateMove(this));
        //stateMachine.AddTransition(StateType.Idle, StateType.Jump, () => StateFuncUtils.IsTranslateJump(this));
        //stateMachine.AddTransition(StateType.Idle, StateType.Attack, () => StateFuncUtils.IsTranslateAttack(this));

        //stateMachine.AddTransition(StateType.Run, StateType.Jump, () => StateFuncUtils.IsTranslateJump(this));
        //stateMachine.AddTransition(StateType.Run, StateType.Idle, () => StateFuncUtils.IsTranslateIdle(this));
  

        //stateMachine.AddTransition(StateType.Attack, StateType.Idle, () => StateFuncUtils.IsTranslateIdle(this));

        //stateMachine.AddTransition(StateType.Jump, StateType.Idle, () => StateFuncUtils.IsTranslateIdle(this));
        playerCtrl = new PlayerCtrl(this);
    }

    protected override void InitComponents()
    {
        base.InitComponents();
    }

    public void InitData(int id, int oripos, int dir)
    {
        base.InitData(id);

        var transformComponent = this.GetComponent<TransformComponent>();
        transformComponent.SetPosX(oripos);
        transformComponent.SetDirection(dir);

        var renderComponent = this.GetComponent<RenderComponent>();
        renderComponent.needMirror = true;
    }

    public override void OnUpdate(float deltaTime)
    {
        if (this.playerCtrl != null)
        {
            this.playerCtrl.Update();
        }
        if (this.stateMachine != null)
        {
            this.stateMachine.Update(deltaTime);
        }
       
    }
    public override void Destroy()
    {
        if (this.stateMachine != null)
        {
            this.stateMachine.Destroy();
        }
    }
}
