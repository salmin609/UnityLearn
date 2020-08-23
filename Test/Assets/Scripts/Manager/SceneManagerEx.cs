using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public void LoadScene(Define.Scenes scene)
    {
        Managers.Clear();
        SceneManager.LoadScene(GetSceneName(scene));
    }

    string GetSceneName(Define.Scenes scene)
    {
        return System.Enum.GetName(typeof(Define.Scenes), scene);
    }

    public BaseScene CurrentScene => GameObject.FindObjectOfType<BaseScene>() as BaseScene;

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
