using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public abstract class UiBase : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> objects = new Dictionary<Type, Object[]>();

    public abstract void Init();
    protected void Bind<T>(Type type) where T : Object
    {
        string[] names = Enum.GetNames(type);
        Object[] objectNames = new Object[names.Length];
        objects.Add(typeof(T), objectNames);

        for (int i = 0; i < names.Length; ++i)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objectNames[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                objectNames[i] = Util.FindChild<T>(gameObject, names[i], true);
            }

            if (objectNames[i] == null)
            {
                Debug.Log($"Failed to bind {names[i]}");
            }
        }
    }
    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        if (objects.TryGetValue(typeof(T), out var objectsName) == false)
            return null;

        return objectsName[index] as T;
    }

    protected Text GetText(int index)
    {
        return Get<Text>(index);
    }

    protected Button GetButton(int index)
    {
        return Get<Button>(index);
    }
    protected Image GetImage(int index)
    {
        return Get<Image>(index);
    }

    public static void AddUiEvent(GameObject obj, Action<PointerEventData> action, Define.UiEvent type = Define.UiEvent.Click)
    {
        UiEventHandler eventHandler = Util.GetOrAddComponent<UiEventHandler>(obj);

        switch (type)
        {
            case Define.UiEvent.Click:
                if (action != null)
                {
                    eventHandler.OnClickHandler -= action;
                    eventHandler.OnClickHandler += action;
                }

                break;
            case Define.UiEvent.Drag:
                if (action != null)
                {
                    eventHandler.OnDragHandler -= action;
                    eventHandler.OnDragHandler += action;
                }

                break;
        }
    }
}
