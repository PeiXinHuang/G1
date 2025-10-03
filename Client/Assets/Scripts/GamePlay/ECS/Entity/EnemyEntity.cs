using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyEntity : RoleEntity
{
    private EnemyCtrl enemyCtrl;
    public EnemyEntity() : base()
    {
        stateMachine.AddState(StateType.Idle, new IdleState(stateMachine, this));
        stateMachine.AddState(StateType.Run, new MoveState(stateMachine, this));
        stateMachine.AddState(StateType.Attack, new AttackState(stateMachine, this));
        stateMachine.ChangeState(StateType.Idle);

        this.enemyCtrl = new EnemyCtrl(this);
    }

    protected override void InitComponents()
    {
        base.InitComponents();
    }

    public void InitData(int id, int originPos, int dir)
    {
        base.InitData(id);

        var transformComponent = this.GetComponent<TransformComponent>();
        transformComponent.SetPosX(originPos);
        transformComponent.SetDirection(dir); // Default direction to right
    }

    public override void OnUpdate(float deltaTime)
    {
        if(this.enemyCtrl != null)
        {
            this.enemyCtrl.Update();
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
