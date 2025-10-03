using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    private static int id = 0;
    public List<Entity> entities = new List<Entity>();
    public List<BaseSystem> systems = new List<BaseSystem>();

    // Fixed method declarations with proper implementation
    public virtual void Enter()
    {
        // Add logic for entering the world if needed
    }

    public virtual void Update(float deltaTime)
    {
        // Add logic for updating the world with deltaTime
        foreach (var entity in entities)
        {
            entity.OnUpdate(deltaTime);
        }

        foreach (var system in systems)
        {
            system.Update(deltaTime);
        }
    }

    public virtual void Exit()
    {
        foreach (var system in systems)
        {
            system.Destroy();
        }
        // Add logic for exiting the world if needed
        foreach (var entity in entities)
        {
            entity.Destroy();
        }

        entities.Clear();
    }

    // Uncommented and fixed CreateEntity and DestroyEntity methods
    public T CreateEntity<T>() where T : Entity, new()
    {
        T entity = new T();
        entity.id = id++;
        entities.Add(entity);
        return entity;
    }

    public void DestroyEntity(int id)
    {
        Entity entity = entities.Find(e => e.id == id);
        if (entity != null)
        {
            entities.Remove(entity);
        }
    }

    public List<Entity> GetEntityWithComponent<T>() where T : BaseComponent
    {
        List<Entity> result = new List<Entity>();
        foreach (var entity in entities)
        {
            if (entity.GetComponent<T>() != null)
            {
                result.Add(entity);
            }
        }
        return result;
    }
    public List<Entity> GetEntityWithComponents(params Type[] componentTypes)
    {
        List<Entity> result = new List<Entity>();
        foreach (var entity in entities)
        {
            bool hasAllComponents = true;
            foreach (var type in componentTypes)
            {
                var method = typeof(Entity).GetMethod("GetComponent").MakeGenericMethod(type);
                var comp = method.Invoke(entity, null);
                if (comp == null)
                {
                    hasAllComponents = false;
                    break;
                }
            }
            if (hasAllComponents)
            {
                result.Add(entity);
            }
        }
        return result;
    }
   
    public void AddSystem(BaseSystem system)
    {
        systems.Add(system);
    }

}
