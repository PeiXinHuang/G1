using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyEntity : RoleEntity
{
    public EnemyEntity() : base()
    {
        stateMachine.AddState(StateType.Idle, new IdleState(stateMachine, this));
        stateMachine.ChangeState(StateType.Idle);

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
