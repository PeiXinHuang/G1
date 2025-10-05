using Unity.VisualScripting;
using UnityEngine;

public class ColliderComponent : BaseComponent
{
    public BoxCollider2D collider;
    public bool hasSetBoxCollider = false;
    public override void OnDestroy()
    {
        collider = null;
        hasSetBoxCollider = false;
    } 

}