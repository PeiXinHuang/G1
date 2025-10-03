using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCtrl : BaseCtrl
{

    private PlayerEntity  playerEntity;
    public PlayerCtrl(PlayerEntity entity) : base(entity)
    {
        this.playerEntity = entity;
    }

    public void Update()
    {
        if (playerEntity != null)
        {
            if (this.CheckAttack())
                this.playerEntity.UpdateState(StateType.Attack);
            else if (this.CheckJump())
                this.playerEntity.UpdateState(StateType.Jump);
            else if(this.CheckMove())
                this.playerEntity.UpdateState(StateType.Run);
            else
                this.playerEntity.UpdateState(StateType.Idle);
        }
    }

    private bool CheckAttack()
    {
        if(isInAttack())
        {
            return true;
        }
        return InputMgr.Instance.GetActionDown(InputAction.Attack);
    }

    private bool CheckJump()
    {
        if (!this.IsOnGround())
        {
            return true;
        }
        return InputMgr.Instance.GetActionDown(InputAction.Jump);
    }

    private bool CheckMove()
    {
        bool isMove = InputMgr.Instance.GetAction(InputAction.MoveLeft) || InputMgr.Instance.GetAction(InputAction.MoveRight);
        if (isMove)
        {
            var dir = InputMgr.Instance.GetMoveDirection();
            this.playerEntity.SetDirection(dir);
            this.playerEntity.SetMove(true);
        }
        else
        {
            this.playerEntity.SetMove(false);
        }
        return isMove;
    }


    private bool IsOnGround()
    {
        return playerEntity.GetComponent<TransformComponent>().position.y < 0.00005;
    }


}
