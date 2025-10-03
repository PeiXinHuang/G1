using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSystem : BaseSystem
{

    public RenderSystem(World world) : base(world)
    {
    }
    public override void Update(float deltaTime)
    {
       var matchEntity = world.GetEntityWithComponent<RenderComponent>();
       for (int i = 0; i < matchEntity.Count; i++)
       {
           var entity = matchEntity[i];
           var renderComponent = entity.GetComponent<RenderComponent>(); 
           if (renderComponent.renderingPath != null && renderComponent.isLoad == false)
           {
                ResMgr.Instance.LoadObj(renderComponent.renderingPath, (GameObject gameObject) =>
                {
                    renderComponent.gameObject = GameObject.Instantiate(gameObject); 
                    renderComponent.animator = renderComponent.gameObject.GetComponent<Animator>();
                });
                renderComponent.isLoad = true;
            }
            if (renderComponent.isDirty && renderComponent.animator)
            {
                renderComponent.animator.CrossFade(renderComponent.aniName, 0.1f);
                renderComponent.isDirty = false;
            }
        }
    }
}
