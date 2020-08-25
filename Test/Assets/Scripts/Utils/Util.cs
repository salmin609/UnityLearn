using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Util : MonoBehaviour
{
    public static T GetOrAddComponent<T>(GameObject obj) where T : UnityEngine.Component
    {
        T component = obj.GetComponent<T>();
        if (component == null)
        {
            component = obj.AddComponent<T>();
        }
        return component;
    }
    public static GameObject FindChild(GameObject obj, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(obj, name, recursive);

        if (transform != null)
            return transform.gameObject;

        return null;
    }
    public static T FindChild<T>(GameObject obj, string name = null, bool recursive = false)
        where T : UnityEngine.Object
    {
        if (obj == null)
            return null;

        if (!recursive)
        {
            int childCount = obj.transform.childCount;
            for (int i = 0; i < childCount; ++i)
            {
                Transform childTransform = obj.transform.GetChild(i);

                if (string.IsNullOrEmpty(name) || childTransform.name == name)
                {
                    T component = childTransform.GetComponent<T>();

                    if (component != null)
                    {
                        return component;
                    }
                }
            }
        }
        else
        {
            foreach (T component in obj.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(component.name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    public static Object FindObjectTypeOrInstantiate(Type objType, string path, string name)
    {
        Object obj = Object.FindObjectOfType(objType);

        if (obj == null)
        {
            Managers.Resource.Instantiate(path).name = name;
        }

        return obj;
    }

    public static GameObject FindGamObjectOrMake(string name, out bool isNullatFirst, bool isDestroyable = true)
    {
        GameObject obj = GameObject.Find(name);

        if (obj == null)
        {
            obj = new GameObject
            {
                name = name
            };

            if (isDestroyable == false)
            {
                Object.DontDestroyOnLoad(obj);
            }

            isNullatFirst = true;
        }
        else
        {
            isNullatFirst = false;
        }

        return obj;
    }
    public static GameObject FindGamObjectOrMake(string objName, Action<GameObject> act, bool isDestroyable = true)
    {
        GameObject obj = GameObject.Find(objName);

        if (obj == null)
        {
            obj = new GameObject
            {
                name = objName
            };

            if (isDestroyable == false)
            {
                Object.DontDestroyOnLoad(obj);
            }
            act.Invoke(obj);
        }

        return obj;
    }

    public static Vector2 VectorInterpolationOneToMinusOne(Vector2 val)
    {
        Vector2 returnVal = Vector2.zero;
        if (val.x > 0.0f)
        {
            returnVal.x = 1.0f;
        }
        else if (val.x < 0.0f)
        {
            returnVal.x = -1.0f;
        }

        if (val.y > 0.0f)
        {
            returnVal.y = 1.0f;
        }
        else if (val.y < 0.0f)
        {
            returnVal.y = -1.0f;
        }
        return returnVal;
    }
}