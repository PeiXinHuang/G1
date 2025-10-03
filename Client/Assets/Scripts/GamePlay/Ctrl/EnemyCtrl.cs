using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : BaseCtrl
{
    private EnemyEntity enemyEntity;
    public EnemyCtrl(EnemyEntity entity) : base(entity)
    {
        this.enemyEntity = entity;
    }

    public void Update()
    {
        if (enemyEntity != null)
        {
            if (this.CheckAttack())
                this.enemyEntity.UpdateState(StateType.Attack);
            else if (this.CheckFollow())
                this.enemyEntity.UpdateState(StateType.Run);
            else
                this.enemyEntity.UpdateState(StateType.Idle);
        }
    }

    private bool CheckAttack()
    {
        if(this.isInAttack())
        {
            return true;
        }
        var playerEntity = EntityMgr.Instance.GetPlayerEntity();
        if (playerEntity != null)
        {
            float distance = CommonUtils.GetTranDisX(enemyEntity.GetComponent<TransformComponent>(), playerEntity.GetComponent<TransformComponent>());
            if (distance < 3.0f)
            {
                this.enemyEntity.SetDirection(CommonUtils.GetToTargetTranDir(
                         this.enemyEntity.GetComponent<TransformComponent>(), playerEntity.GetComponent<TransformComponent>()));
                this.enemyEntity.SetMove(false);
                return true;
            }
        }
        return false;
    }

    private bool CheckFollow()
    {
        var playerEntity = EntityMgr.Instance.GetPlayerEntity();
        {
            if (playerEntity != null) {
                float distance = CommonUtils.GetTranDisX(enemyEntity.GetComponent<TransformComponent>(), playerEntity.GetComponent<TransformComponent>());
                if (distance < 5.0f)
                {
                    this.enemyEntity.SetMove(true);
                    this.enemyEntity.SetDirection(CommonUtils.GetToTargetTranDir(
                        this.enemyEntity.GetComponent<TransformComponent>(), playerEntity.GetComponent<TransformComponent>()));
                    return true;
                }
                else
                {
                    this.enemyEntity.SetMove(false);
                }
            }
        }
        return false;
    }
}
