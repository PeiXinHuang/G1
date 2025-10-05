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

    public void InitData(int modelId, int originPos, int dir)
    {
        base.InitData(modelId);

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
        base.OnUpdate(deltaTime);

    }
    public override void Destroy()
    {
        base.Destroy();
    }
}
