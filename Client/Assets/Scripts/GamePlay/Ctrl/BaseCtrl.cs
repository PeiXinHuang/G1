
public class BaseCtrl
{   
    private RoleEntity entity;
    public BaseCtrl(RoleEntity entity)
    {
        this.entity = entity;
    }

    protected bool isInAttack()
    {
        return this.entity.GetComponent<SkillComponent>().skillId != 0;
    }
}
