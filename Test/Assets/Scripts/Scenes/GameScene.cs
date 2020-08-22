using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    void Start()
    {
        Init();
    }
    protected override void Init()
    {
        base.Init();

        sceneType = Define.Scenes.Game;

        Managers.Ui.ShowSceneUi<UiInventory>();
    }

    public override void Clear()
    {

    }
}
