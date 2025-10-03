using UnityEngine;

public class JumpState : State
{
    public JumpState(StateMachine stateMachine, RoleEntity roleEntity) :
        base(stateMachine, roleEntity)
    {
    }

    public override void Enter()
    {
        this.roleEntity.PlayAnim(AnimationName.Jump);
        this.roleEntity.SetJump(true);
    }

    public override void Update(float deltaTime)
    {
        // Idle状态下可以根据输入或条件切换到其他状态
        // 这里只做示例，具体逻辑可根据实际需求补充
    }

    public override void Exit()
    {
        // 离开Idle状态时的处理（如有需要）
    }
}

