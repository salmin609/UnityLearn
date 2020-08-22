using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : UiBase
{
    public override void Init()
    {
        Managers.Ui.SetCanvas(gameObject, true);
    }

    public virtual void ClosePopupUi()
    {
        Managers.Ui.ClosePopupUi(this);
    }
}
