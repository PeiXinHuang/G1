using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSystem
{
    protected World world;
    public BaseSystem(World world)
    {
        this.world = world;
    }
    public  virtual void Update(float deltaTime)
    {
        
    }

    public virtual void Destroy() { 
        world = null;   
    }
}
