public class AttackState : State
{
    public AttackState(StateMachine stateMachine, RoleEntity roleEntity) :
         base(stateMachine, roleEntity)
    {
    }

    public override void Enter()
    {
        // ����Idle״̬ʱ������Idle����
        this.roleEntity.PlayAnim(AnimationName.Attack);
        this.roleEntity.PlaySkill(1);
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