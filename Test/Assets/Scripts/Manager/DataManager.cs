using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDictionary();
}

public class DataManager
{
    public Dictionary<int, Stat> statDictionary
    {
        get;
        private set;
    } = new Dictionary<int, Stat>();

    public void Init()
    {
        statDictionary = LoadJson<StatData, int, Stat>("StatData").MakeDictionary();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
