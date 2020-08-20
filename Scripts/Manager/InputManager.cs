﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;

    public Action<Define.MouseEvent> MouseAction = null;

    private bool mousePressed = false;
    // Update is called once per frame
    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                mousePressed = true;
            }
            else
            {
                if (mousePressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                }
                mousePressed = false;
            }
        }
    }
}
