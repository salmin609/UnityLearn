using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameScene : BaseScene
{


    protected override void Init()
    {
        base.Init();
        sceneType = Define.Scenes.NewGame;
        Managers.Sound.Play("FreeSound/Cavern Atmosphere - Loop", Define.Sound.Bgm);
    }

    public override void Clear()
    {
    }
}
