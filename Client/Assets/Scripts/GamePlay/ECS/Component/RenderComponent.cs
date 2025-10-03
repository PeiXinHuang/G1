using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderComponent : BaseComponent
{
    public string renderingPath = null;
    public GameObject gameObject = null;
    public bool isLoad = false;
    public string aniName = "";
    public Animator animator = null;
    public bool isDirty = false;
    public void SetAnimName(string aniName) {
        if (this.aniName == aniName)
        {
            return;
        }
        this.aniName = aniName;
        isDirty = true;
    }
}
