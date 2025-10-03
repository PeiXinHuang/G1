using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : BaseSystem
{

    public SkillSystem(World world) : base(world)
    {
    }
    public override void Update(float deltaTime)
    {
        var matchEntity = EntityMgr.Instance.GetEntityWithComponent<SkillComponent>();
        for (int i = 0; i < matchEntity.Count; i++)
        {
            var entity = matchEntity[i];
            var skillComponent = entity.GetComponent<SkillComponent>();
            if (skillComponent.skillId != 0)
            {
                if(skillComponent.skillTimer <= skillComponent.skillDuration)
                    skillComponent.skillTimer += deltaTime; 
                else
                {
                    skillComponent.skillId = 0;
                    skillComponent.skillTimer = 0;
                }
            }
        }
    }
}
