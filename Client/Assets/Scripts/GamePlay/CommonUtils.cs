

using System;
using UnityEngine;

public static class CommonUtils
{
    public static float GetTranDisX(TransformComponent tran1, TransformComponent tran2)
    {
        return Math.Abs(tran1.position.x - tran2.position.x);
    }

    public static int GetToTargetTranDir(TransformComponent selfComp, TransformComponent targetComp)
    {
        return selfComp.position.x < targetComp.position.x ? 1 : -1;
    }

}