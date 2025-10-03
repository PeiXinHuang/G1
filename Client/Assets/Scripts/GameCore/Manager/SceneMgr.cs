using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneMgr : Singleton<SceneMgr>
{
    private GameObject curScene;
    public void LoadScene(string sceneName, Action loadComplete = null)
    {
        if (curScene != null)
        {
            GameObject.Destroy(curScene);
        }
        ResMgr.Instance.LoadScene(sceneName, (GameObject obj) =>
        {
            this.curScene = GameObject.Instantiate(obj);
            loadComplete?.Invoke(); 
        });
    }

    public GameObject GetCurScene()
    {
        return this.curScene;    
    }
}
