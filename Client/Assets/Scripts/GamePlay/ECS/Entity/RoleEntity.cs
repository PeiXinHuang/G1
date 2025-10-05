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
        this.AddComponent<ColliderComponent>();
        this.AddComponent<AttrComponent>();
    }

    public void InitData(int modelId)
    {
        base.InitData();
        var renderComponent = this.GetComponent<RenderComponent>();
        renderComponent.renderingPath = string.Format("Role/{0}/{0}", modelId, modelId);
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
        moveComponent.SetJump(isJump);
    }

    public bool IsOnGround()
    {
        var transformComponent = this.GetComponent<TransformComponent>();
        return transformComponent.position.y <= 0.00005;
    }


    public void PlaySkill(int id)
    {
        var skillComponent = this.GetComponent<SkillComponent>();
        if (skillComponent.skillId == 0)
        {
            var transformComponent = this.GetComponent<TransformComponent>();
            skillComponent.StartSkill(id, this.id, transformComponent.position);
        }
    }

    public void StopSkill()
    {
        var skillComponent = this.GetComponent<SkillComponent>();
        foreach (var box in skillComponent.attackBoxList)
        {
            GameObject.Destroy(box);
        }
        skillComponent.attackBoxList.Clear();
        skillComponent.skillId = 0;
    }

    public void OnHurt(int value)
    {
        var attrComp = this.GetComponent<AttrComponent>();
        attrComp.curHp -= value;
        if (attrComp.curHp <= 0)
        {
            this.Die();
        }

    }

    public void OnRecoverd(int value)
    {

    }

    public void Die()
    {
        EntityMgr.Instance.DestroyEntity(id);
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
        base.Destroy();
        if (this.stateMachine != null)
        {
            this.stateMachine.Destroy();
        }
    }
}
