using System.Collections.Generic;
using UnityEngine;

public class SkillComponent : BaseComponent
{
    public int skillId = 0;
    public float skillTimer = 0f;
    public float skillDuration = 0.3f;
    public float skillCdTimer = 0f;
    public float skillCdDuration = 2.0f;
    public int damage = 0;

    public List<GameObject> attackBoxList = new List<GameObject>();

    public void StartSkill(int skillId, int ownerId, Vector2 pos)
    {
        this.skillId = skillId;
        this.skillCdTimer = 0f;
        this.skillTimer = 0f;

        var emptyAttackBox = new GameObject();
        emptyAttackBox.layer = LayerMask.NameToLayer(LayerName.AttackBox);
        var boxCollider = emptyAttackBox.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        emptyAttackBox.AddComponent<EntityTag>().entityId = ownerId;

        boxCollider.transform.position = pos;
        boxCollider.size = new Vector2(1.5f, 1.0f);
        boxCollider.offset = new Vector2(0f, 0.5f);

        attackBoxList.Add(emptyAttackBox);
    }

    public void StopSkill()
    {
        foreach (var box in attackBoxList)
        {
            GameObject.Destroy(box);
        }
        attackBoxList.Clear();
    }

    public void FinishSkill()
    {
        skillId = 0;
        this.skillCdTimer = 0f;
        this.skillTimer = 0f;
    }
}