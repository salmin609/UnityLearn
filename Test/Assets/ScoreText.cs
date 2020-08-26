using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public static int score = 0;
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = $"Score : {score}";
    }
}
