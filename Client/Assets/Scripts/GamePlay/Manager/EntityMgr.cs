using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class EntityMgr : Singleton<EntityMgr>
{
    private static int id = 0;

    private List<Entity> entities = new List<Entity>();

    private PlayerEntity playerEntity = null;

    // Rename the method to avoid conflict with Unity's built-in Update method
    public void UpdateEntities(float deltaTime)
    {
        // Add logic for updating the world with deltaTime
        foreach (var entity in entities)
        {
            entity.OnUpdate(deltaTime);
        }
    }

    public void ClearEntities()
    {
        // Add logic for exiting the world if needed
        foreach (var entity in entities)
        {
            entity.Destroy();
        }
        entities.Clear();
        this.playerEntity = null;
    }

    public T CreateEntity<T>() where T : Entity, new()
    {
        T entity = new T();
        entity.id = id++;
        entities.Add(entity);
        if(entity is PlayerEntity)
        {
            playerEntity = entity as PlayerEntity;
        }
        return entity;
    }

    public void DestroyEntity(int id)
    {
        Entity entity = entities.Find(e => e.id == id);
        if (entity != null)
        {
            entities.Remove(entity);
        }

        if(this.playerEntity != null && entity == this.playerEntity)
        {
            this.playerEntity = null;
        }

        entity.Destroy();
        entity = null;


    }

    public PlayerEntity GetPlayerEntity()
    {
        return playerEntity;
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

    protected override void  OnDestroy()
    {
        this.ClearEntities();
        base.OnDestroy();
    }
}
