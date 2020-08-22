using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInventory : UiScene
{
    enum GameObjects
    {
        GridPanel
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int) GameObjects.GridPanel);

        foreach (Transform child in gridPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }

        for (int i = 0; i < 8; ++i)
        {
            GameObject item = Managers.Ui.MakeSubItem<UiInvenItem>(parent : gridPanel.transform).gameObject;

            UiInvenItem itemInfo = item.GetOrAddComponent<UiInvenItem>();
            itemInfo.SetInfo($"mtf {i}");
        }
    }
}
