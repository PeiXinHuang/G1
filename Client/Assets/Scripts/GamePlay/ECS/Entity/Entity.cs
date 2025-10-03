using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public int id;

    private List<BaseComponent> components = null;

    public void AddComponent<T>() where T : BaseComponent, new()
    {
        if (components == null)
        {
            components = new List<BaseComponent>();
        }
        if (this.GetComponent<T>() != null)
        {
            Debug.LogWarning($"Entity {id} already has a component of type {typeof(T).Name}");
            return;
        }
        components.Add(new T());
    }

    public void RemoveComponent<T>() where T : BaseComponent
    {
        if (components == null) return;
        BaseComponent componentToRemove = null;
        foreach (var component in components)
        {
            if (component is T)
            {
                componentToRemove = component;
                break;
            }
        }
        if (componentToRemove != null)
        {
            components.Remove(componentToRemove);
        }
    }

    public T GetComponent<T>() where T : BaseComponent
    {
        if (components == null) return null;
        foreach (var component in components)
        {
            if (component is T)
            {
                return component as T;
            }
        }
        return null;
    }

    protected virtual void InitComponents()
    {

    }

    public virtual void InitData(int id)
    {
        this.id = id;
    }

    public Entity()
    {
        InitComponents();
    }


    public virtual void OnUpdate(float deltaTime)
    {
    
    }
    public virtual void Destroy()
    {

    }
}

