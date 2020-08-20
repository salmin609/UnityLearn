﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers manager;

    static Managers Manager
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
    ResourceManager ResourceManager = new ResourceManager();

    public static ResourceManager Resource
    {
        get
        {
            return manager.ResourceManager;
        }
    }
    void Start()
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
        }

    }
}
