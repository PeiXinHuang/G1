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
        playerCtrl = new PlayerCtrl(this);
    }

    protected override void InitComponents()
    {
        base.InitComponents();
    }

    public void InitData(int modelId, int oripos, int dir)
    {
        base.InitData(modelId);

        var transformComponent = this.GetComponent<TransformComponent>();
        transformComponent.SetPosX(oripos);
        transformComponent.SetDirection(dir);

        var attrComponent = this.GetComponent<AttrComponent>();
        attrComponent.maxHp = 100;
        attrComponent.curHp = 100;

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
        base.Destroy();
    }
}
