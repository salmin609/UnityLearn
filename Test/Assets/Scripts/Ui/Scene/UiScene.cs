using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScene : UiBase
{
    public override void Init()
    {
        Managers.Ui.SetCanvas(gameObject, false);
    }
}
