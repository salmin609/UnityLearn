using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private Coroutine co;

    protected override void Init()
    {
        base.Init();

        sceneType = Define.Scenes.Game;

        Managers.Ui.ShowSceneUi<UiInventory>();

        
        Dictionary<int, Stat> stat = Managers.Data.statDictionary;

        #region HowToPool
        //for (int i = 0; i < 5; ++i)
        //{
        //    Managers.Resource.Instantiate("character");
        //}
        #endregion

        #region HowToUseCoroutine
        co = StartCoroutine("CoCheckAfterSeconds", 4.0f);
        StartCoroutine("CoStopAfterSeconds", 2.0f);
        #endregion
    }

    public override void Clear()
    {

    }

    #region CoroutineFunctions
    IEnumerator CoCheckAfterSeconds(float second)
    {
        Debug.Log($"CoRoutin second : {second}");
        yield return new WaitForSeconds(second);
        Debug.Log("CoRoutin end");
        co = null;
    }
    IEnumerator CoStopAfterSeconds(float second)
    {
        Debug.Log($"StopCoRoutin second : {second}");
        yield return new WaitForSeconds(second);
        Debug.Log("StopCoRoutin end");
        if (co != null)
        {
            StopCoroutine(co);
            co = null;
        }
    }
    #endregion
}
