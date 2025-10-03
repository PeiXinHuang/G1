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
        // Idle״̬�¿��Ը�������������л�������״̬
        // ����ֻ��ʾ���������߼��ɸ���ʵ�����󲹳�
    }

    public override void Exit()
    {
        // �뿪Idle״̬ʱ�Ĵ���������Ҫ��
    }
}

