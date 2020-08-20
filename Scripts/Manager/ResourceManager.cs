using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        return Object.Instantiate(prefab, parent);
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
