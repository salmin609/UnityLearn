using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefab/{path}");
        if (prefab == null)
        {
            Debug.Log("What the fuck r u doing");
            return null;
        }
        
        GameObject obj = Object.Instantiate(prefab, parent);

        int index = obj.name.IndexOf("(Clone)");

        if (index > 0)
        {
            obj.name = obj.name.Substring(0, index);
        }

        return obj;
    }

    public void Destroy(GameObject obj)
    {
        if (obj != null)
        {
            Object.Destroy(obj);
        }
    }

    public void Destroy(GameObject obj, float time)
    {
        if (obj != null)
        {
            Object.Destroy(obj, time);
        }
    }
}
