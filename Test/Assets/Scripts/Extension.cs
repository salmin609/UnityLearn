using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static void AddUiEvent(this GameObject obj, Action<PointerEventData> action,
        Define.UiEvent type = Define.UiEvent.Click)
    {
        UiBase.AddUiEvent(obj, action, type);
    }

}
