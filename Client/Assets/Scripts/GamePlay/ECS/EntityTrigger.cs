using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(LayerName.AttackBox))
        {
            var tag = other.gameObject.GetComponent<EntityTag>();
            if (tag != null)
            {
                var myEntityId = this.GetComponent<EntityTag>().entityId;
                var entity = EntityMgr.Instance.GetEntityByEntityId(myEntityId);
                if(entity != null && entity is RoleEntity && myEntityId != tag.entityId)
                    ( entity  as RoleEntity).OnHurt(5); //这里需要拿到伤害box的数值
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }


}
