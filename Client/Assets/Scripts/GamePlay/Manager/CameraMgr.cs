using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class CameraMgr : Singleton<CameraMgr>
{
    private Camera mainCamera;

    public Camera GetMainCamera()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        return mainCamera;
    }


    public void SetMainCameraPos(float x, float y)
    {
        Vector3 targetPosition = new Vector3(x, y, GetMainCamera().transform.position.z);
        GetMainCamera().transform.position = targetPosition;
    }

    public TransformComponent target; // The target for the camera to follow
    public float smoothSpeed = 0.125f; // The speed of the camera smoothing
    public Vector2 offset; // Offset from the target position
    void LateUpdate()
    {
        if (target == null)
            return;
        Vector2 desiredPosition = new Vector2(target.position.x + offset.x, transform.position.y + offset.y);
        Vector2 smoothedPosition = Vector2.Lerp(GetMainCamera().transform.position, desiredPosition, smoothSpeed);
        CameraMgr.Instance.SetMainCameraPos(smoothedPosition.x, smoothedPosition.y);
    }

    public void SetTarget(TransformComponent newTarget)
    {
        target = newTarget;
    }

    public void SetOffset(int x, int y)
    {
        offset = new Vector2(x, y);
    }
}