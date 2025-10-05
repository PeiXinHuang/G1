using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderComponent : BaseComponent
{
    public string renderingPath = null;
    public GameObject gameObject = null;
    public bool isLoad = false;
    public bool hasLoad = false;
    public string aniName = "";
    public Animator animator = null;
    public bool isDirty = false;
    public bool needMirror = false; //模型是否需要镜像
    public void SetAnimName(string aniName) {
        if (this.aniName == aniName)
        {
            return;
        }
        this.aniName = aniName;
        isDirty = true;
    }

    public override void OnDestroy()
    {
        if (gameObject != null)
        {
            GameObject.Destroy(gameObject);
            gameObject = null;
        }
        animator = null;
        this.isLoad = false;
        this.hasLoad = false;
    }
}
