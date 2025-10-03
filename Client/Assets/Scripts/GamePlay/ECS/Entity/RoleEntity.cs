using System;
using Unity.VisualScripting;
using UnityEngine;

public class RoleEntity : Entity
{
    public StateMachine stateMachine;
    public RoleEntity() : base()
    {
        // Constructor logic if needed
        stateMachine = new StateMachine();

    }

    protected override void InitComponents()
    {
        // Initialization logic for the RoleEntity
        this.AddComponent<RenderComponent>();
        this.AddComponent<TransformComponent>();
        this.AddComponent<MoveComponent>();
        this.AddComponent<SkillComponent>();
    }

    public override void InitData(int id)
    {
        base.InitData(id);
        var renderComponent = this.GetComponent<RenderComponent>();
        renderComponent.renderingPath = string.Format("Role/{0}/{0}", id, id);
    }

    public void PlayAnim(string aniName)
    {
        var renderComponent = this.GetComponent<RenderComponent>();
        renderComponent.SetAnimName(aniName);
    }

    public void SetDirection(int dir)
    {
        var transformComponent = this.GetComponent<TransformComponent>();
        transformComponent.SetDirection(dir);
    }
    public void SetMove(bool isMove)
    {
        var moveComponent = this.GetComponent<MoveComponent>();
        moveComponent.moveSpeed = isMove ? moveComponent.moveValue : 0;
        moveComponent.isMoving = isMove;
    }

    public void SetJump(bool isJump)
    {
        var moveComponent = this.GetComponent<MoveComponent>();

        moveComponent.upSpeed = isJump ? moveComponent.jumpValue : 0;
        moveComponent.isJumping = isJump;
    }


    public void PlaySkill(int id)
    {
        var skillComponent = this.GetComponent<SkillComponent>();
        Debug.Log($"PlaySkill: {id}");
        skillComponent.skillId = 1;
    }

    public void UpdateState(StateType stateType)
    {
        this.stateMachine.ChangeState(stateType);
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
