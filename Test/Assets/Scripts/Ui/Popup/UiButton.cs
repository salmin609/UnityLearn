using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UiButton : UIPopup
{
    [SerializeField] private Text text;

    private int score = 0;

    enum Buttons
    {
        PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText
    }

    enum GameObjects
    {
        TestObject,
    }

    enum Images
    {
        ItemIcon
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClick);

        GameObject obj = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(obj, (PointerEventData data) => { obj.transform.position = data.position; }, Define.UiEvent.Drag);
    }

    public void OnButtonClick(PointerEventData data)
    {
        score++;

        Get<Text>((int)Texts.ScoreText).text = $"your score is {score} mtf";
    }
}
