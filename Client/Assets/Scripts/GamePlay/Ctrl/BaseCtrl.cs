
using UnityEngine;

public class BaseCtrl
{
    private RoleEntity entity;
    public BaseCtrl(RoleEntity entity)
    {
        this.entity = entity;
    }

    protected bool IsInAttack()
    {
        var skillComp = this.entity.GetComponent<SkillComponent>();
        return skillComp.skillId != 0 && skillComp.skillTimer < skillComp.skillDuration;
    }

    protected bool IsInSkillCd()
    {
        var skillComp = this.entity.GetComponent<SkillComponent>();
        return skillComp.skillId != 0 && skillComp.skillCdTimer < skillComp.skillCdDuration;
    }
}
