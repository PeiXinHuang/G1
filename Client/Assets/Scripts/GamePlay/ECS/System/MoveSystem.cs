using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : BaseSystem
{
    public MoveSystem(World world) : base(world)
    {
        // Constructor logic if needed  
    }

    public override void Update(float deltaTime)
    {
        var matchEntity = world.GetEntityWithComponents(new Type[] { typeof(MoveComponent), typeof(TransformComponent) });
        for (int i = 0; i < matchEntity.Count; i++)
        {
            var entity = matchEntity[i];
            var moveComponent = entity.GetComponent<MoveComponent>();
            var transformComponent = entity.GetComponent<TransformComponent>();

            if (moveComponent.isJumping)
            {
                transformComponent.SetPosY(transformComponent.position.y + moveComponent.upSpeed * deltaTime);
                moveComponent.upSpeed -= 9.8f * deltaTime;
            }

            if(moveComponent.isMoving)
            {
                transformComponent.SetPosX(transformComponent.position.x + moveComponent.speed* deltaTime * transformComponent.direction);
            }
                
            if(transformComponent.position.y <= 0)
            {
                (entity as RoleEntity).SetJump(false);
            }

        }

        matchEntity = world.GetEntityWithComponents(new Type[] {typeof(TransformComponent), typeof(RenderComponent)});
        for (int i = 0; i < matchEntity.Count; i++)
        {
            var entity = matchEntity[i];
            var transformComponent = entity.GetComponent<TransformComponent>();
            var renderComponent = entity.GetComponent<RenderComponent>();
            if (transformComponent != null && transformComponent.isDirtyPos && renderComponent.gameObject)
            {
                var curPos = renderComponent.gameObject.transform.position;
                // Update the position of the GameObject based on the TransformComponent
                renderComponent.gameObject.transform.position = transformComponent.position;
            }
            if (transformComponent != null && transformComponent.isDirtyDir && renderComponent.gameObject)
            {
                // Update the scale of the GameObject based on the direction
                renderComponent.gameObject.transform.localScale = new Vector3(transformComponent.direction * (-1), 1, 1);
            }
        }
    }
}
