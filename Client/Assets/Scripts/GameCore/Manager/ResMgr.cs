using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class ResMgr : Singleton<ResMgr>
{
    const string RESOURCES_PATH = "Scene/";
    public void LoadScene(string sceneName, Action<GameObject> onLoadComplete = null)
    {
        ResourceRequest request = Resources.LoadAsync<GameObject>(string.Format("{0}{1}", RESOURCES_PATH, sceneName));
        request.completed += (AsyncOperation operation) =>
        {
            if (request.asset == null)
            {
                Debug.LogError($"Failed to load scene: {sceneName}. Asset is null.");
                onLoadComplete?.Invoke(null);
                return;
            }
            Debug.Log($"Scene {sceneName} loaded successfully.");
            if (request.asset is GameObject loadedObject)
            {
                onLoadComplete?.Invoke(loadedObject);
            }
            else
            {
                onLoadComplete?.Invoke(null);
            }
        };
    }

    public void LoadObj(string objPath, Action<GameObject> onLoadComplete = null)
    {
        ResourceRequest request = Resources.LoadAsync<GameObject>(string.Format("{0}", objPath));
        request.completed += (AsyncOperation operation) =>
        {
            if (request.asset == null)
            {
                Debug.LogError($"Failed to load obj: {objPath}. Asset is null.");
                onLoadComplete?.Invoke(null);
                return;
            }
            Debug.Log($"obj {objPath} loaded successfully.");
            if (request.asset is GameObject loadedObject)
            {
                onLoadComplete?.Invoke(loadedObject);
            }
            else
            {
                onLoadComplete?.Invoke(null);
            }
        };
    }
}
