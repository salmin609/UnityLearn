using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');

            if (index > 0)
            {
                name = name.Substring(index + 1);
            }

            GameObject obj = Managers.Pool.GetOriginal(name);

            if (obj != null)
            {
                return obj as T;
            }
        }

        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefab/{path}");
        if (original == null)
        {
            Debug.Log("Path is wrong");
            return null;
        }

        if (original.GetComponent<PoolAble>() != null)
        {
            return Managers.Pool.Pop(original, parent).gameObject;
        }
        
        GameObject obj = Object.Instantiate(original, parent);
        obj.name = original.name;


        //int index = obj.name.IndexOf("(Clone)");

        //if (index > 0)
        //{
        //    obj.name = obj.name.Substring(0, index);
        //}

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
            PoolAble poolAble = obj.GetComponent<PoolAble>();

            if (poolAble != null)
            {
                Managers.Pool.Push(poolAble);
                return;
            }
             
            Object.Destroy(obj, time);
        }
    }
}
