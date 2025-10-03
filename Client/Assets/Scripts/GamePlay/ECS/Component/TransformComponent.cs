using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformComponent : BaseComponent
{
    public Vector2 position = new Vector2();
    public int direction = 1; // -1 for left, 1 for right
    public bool isDirtyPos = false;
    public bool isDirtyDir = false;
    public void SetPosX(float x)
    {
        position.x = x;
        isDirtyPos = true;
    }

    public void SetPosY(float y)
    {
        position.y = y;
        isDirtyPos = true;
    }

    public void SetDirection(int dir)
    {
        if (dir != -1 && dir != 1)
        {
            Debug.LogError("Direction must be -1 or 1");
            return;
        }
        direction = dir;
        isDirtyDir = true;
    }
}
