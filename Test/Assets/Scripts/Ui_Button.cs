using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Button : MonoBehaviour
{
    [SerializeField] private Text text;

    private int score = 0;

    public void OnButtonClick()
    {
        score++;
        text.text = $"your score is : {score} mtf";
    }
}
