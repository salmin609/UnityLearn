﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers manager;

    public static Managers Manager
    {
        get
        {
            Init();
            return manager;
        }
    }
    InputManager inputManager = new InputManager();

    public static InputManager Input
    {
        get
        {
            return manager.inputManager;
        }
    }
    ResourceManager resourceManager = new ResourceManager();

    public static ResourceManager Resource
    {
        get
        {
            return manager.resourceManager;
        }
    }

    private UiManager uiManager = new UiManager();

    public static UiManager Ui
    {
        get
        {
            return manager.uiManager;
        }
    }

    private SceneManagerEx sceneManager = new SceneManagerEx();

    public static SceneManagerEx Scene
    {
        get
        {
            return manager.sceneManager;
        }
    }

    private SoundManager soundManager = new SoundManager();

    public static SoundManager Sound
    {
        get
        {
            return manager.soundManager;
        }
    }

    void Awake()
    {
        Init();
    }
     
    void Update()
    {
        inputManager.OnUpdate();
    }
    
    static void Init()
    {
        if (manager == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if (go == null)
            {
                go = new GameObject
                {
                    name = "@Managers"
                };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            manager = go.GetComponent<Managers>();

            manager.soundManager.Init();
        }

    }

    public static void Clear()
    {
        Sound.Clear();
        Input.Clear();
        Ui.Clear();
        Scene.Clear();
    }
}
