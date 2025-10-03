public class BattleWorld : World
{
    public override void Enter()
    {
        base.Enter();
        this.AddSystem(new RenderSystem(this));
        this.AddSystem(new MoveSystem(this));
        this.AddSystem(new SkillSystem(this));


        PlayerEntity player = CreateEntity<PlayerEntity>();
        player.InitData(1001, 0, 1);

        InputMgr.Instance.SetOperateEntity(player);

        EnemyEntity enemy = CreateEntity<EnemyEntity>();
        enemy.InitData(1002, -3, -1);

        //CameraMgr.Instance.SetFollowTarget(player.transform, new Vector3(0, 0, -10));
        CameraMgr.Instance.SetOffset(0, 2);
        CameraMgr.Instance.SetTarget(player.GetComponent<TransformComponent>());
    }
    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
