using Unity.VisualScripting;
using UnityEngine;

public static class StateFuncUtils{
    public static bool IsTranslateMove(RoleEntity roleEntity){
        if (!StateFuncUtils.IsOnGround(roleEntity))
        {
            return false;
        }
        return InputMgr.Instance.GetAction(InputAction.MoveLeft) || InputMgr.Instance.GetAction(InputAction.MoveRight);
    }

    public static bool IsTranslateIdle(RoleEntity roleEntity){
        if (StateFuncUtils.IsInAttack(roleEntity))
        {
            return false;
        }
        return !StateFuncUtils.IsTranslateMove(roleEntity);
    }

    public static bool IsTranslateJump(RoleEntity roleEntity)
    {
        if (!StateFuncUtils.IsOnGround(roleEntity))
        {
            return false;
        }
        return InputMgr.Instance.GetActionDown(InputAction.Jump);
    }

    public static bool IsTranslateAttack(RoleEntity roleEntity)
    {
        if(StateFuncUtils.IsInAttack(roleEntity))
        {
            return false;
        }
        if(!StateFuncUtils.IsOnGround(roleEntity))
        {
            return false;
        }
        return InputMgr.Instance.GetActionDown(InputAction.Attack);
    }
    public static bool IsOnGround(RoleEntity roleEntity)
    {
        return roleEntity.GetComponent<TransformComponent>().position.y <  0.00005;
    }

    public static bool IsInAttack(RoleEntity roleEntity)
    {
        return roleEntity.GetComponent<SkillComponent>().skillId != 0;
    }
}

