using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
  
    public List<BaseSystem> systems = new List<BaseSystem>();

    // Fixed method declarations with proper implementation
    public virtual void Enter()
    {
        // Add logic for entering the world if needed
    }

    public virtual void Update(float deltaTime)
    {
        // Add logic for updating the world with deltaTime

        foreach (var system in systems)
        {
            system.Update(deltaTime);
        }
        EntityMgr.Instance.UpdateEntities(deltaTime);
    }

    public virtual void Exit()
    {
        foreach (var system in systems)
        {
            system.Destroy();
        }

 
    }

    // Uncommented and fixed CreateEntity and DestroyEntity methods
   
    public void AddSystem(BaseSystem system)
    {
        systems.Add(system);
    }

}
