﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        sceneType = Define.Scenes.Login;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Managers.Scene.LoadScene(Define.Scenes.Game);
        }
    }

    public override void Clear()
    {
        Debug.Log("hLEELLO");
    }
}
