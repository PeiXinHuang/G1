using System;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSystem : BaseSystem
{
    public ColliderSystem(World world) : base(world)
    {
    }

    public override void Update(float deltaTime)
    {
        var matchEntity = EntityMgr.Instance.GetEntityWithComponents(new Type[]
        {
            typeof(ColliderComponent), typeof(RenderComponent)
        }); 

        for (int i = 0; i < matchEntity.Count; i++)
        {
            var entity = matchEntity[i];
            var colliderComponent = entity.GetComponent<ColliderComponent>();
            var renderComponent = entity.GetComponent<RenderComponent>(); 

            if (colliderComponent != null && renderComponent != null) // Ensure both components exist
            {
                if(renderComponent.hasLoad && colliderComponent.hasSetBoxCollider == false)
                {
                    var collider = renderComponent.gameObject.GetComponent<BoxCollider2D>();
                    if(collider == null)
                    {
                        colliderComponent.collider = renderComponent.gameObject.AddComponent<BoxCollider2D>();
                    }
                    colliderComponent.hasSetBoxCollider = true;
                }
               
            }

            if (renderComponent != null && renderComponent.isDirty && renderComponent.animator)
            {
                renderComponent.animator.CrossFade(renderComponent.aniName, 0.1f);
                renderComponent.isDirty = false;
            }
        }
    }
}
