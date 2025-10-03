using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum InputAction
{
    MoveLeft,
    MoveRight,
    Jump,
    Attack,
    // 可扩展更多动作
}

public class InputMgr : Singleton<InputMgr>
{
    private PlayerEntity operateEntity;
    private TransformComponent operateEntityTransform;

    private Dictionary<InputAction, KeyCode> keyMappings = new Dictionary<InputAction, KeyCode>
    {
        { InputAction.MoveLeft, KeyCode.A },
        { InputAction.MoveRight, KeyCode.D },
        { InputAction.Jump, KeyCode.Space },
    };

    private Dictionary<InputAction, MouseButton> mouseMappings = new Dictionary<InputAction, MouseButton>
    {
        { InputAction.Attack, MouseButton.Left },   // 鼠标左键
    };      

    // 新增：支持鼠标左键作为攻击事件
    public bool GetAction(InputAction action)
    {
        if (mouseMappings.TryGetValue(action, out var mouseButton))
        {
            if (mouseButton == MouseButton.Left)
            {
                return Input.GetMouseButton(0); // 0为鼠标左键
            }
            // 可扩展其他鼠标按钮
        }
        if (keyMappings.TryGetValue(action, out var key))
        {
            return Input.GetKey(key);
        }
        return false;
    }

    public bool GetActionDown(InputAction action)
    {
        if (action == InputAction.Attack)
        {
            if(mouseMappings.TryGetValue(action,out var mouseButton))
            {
                if(mouseButton == MouseButton.Left)
                {
                    return Input.GetMouseButtonDown(0); // 0为鼠标左键
                }
                // 可扩展其他鼠标按钮
            }
        }
        if (keyMappings.TryGetValue(action, out var key))
        {
            return Input.GetKeyDown(key);
        }
        return false;
    }


    public void SetOperateEntity(PlayerEntity entity)
    {
        this.operateEntity = entity;
        if (operateEntity != null)
        {
            operateEntityTransform = operateEntity.GetComponent<TransformComponent>();
            if (operateEntityTransform == null)
            {
                Debug.LogError("Operate entity does not have a TransformCompoent.");
            }
        }
        else
        {
            Debug.LogWarning("SetOperateEntity called with null entity.");
        }
    }

    public PlayerEntity GetOperateEntity()
    {
        return this.operateEntity;
    }

    public int GetMoveDirection()
    {
        if (GetAction(InputAction.MoveLeft))
            return -1;
        if (GetAction(InputAction.MoveRight))
            return 1;
        return 1;
    }


}
