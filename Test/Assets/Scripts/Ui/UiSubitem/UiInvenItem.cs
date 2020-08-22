using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiInvenItem : UiBase
{
    enum GameObjects
    {
        ItemIcon,
        ItemTextName,
    }

    private string name;

    void Start()
    {
        Init();
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int) GameObjects.ItemTextName).GetComponent<Text>().text = $"{name}";

        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent(ptr =>
        {
            Debug.Log($"ItemNum :  { name } ");
            //Debug.Log("Why ssibal");
        });
    }

    public void SetInfo(string name)
    {
        this.name = name;
    }
}
