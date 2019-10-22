using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Checker checker;

    void Awake ()
    {
        scoreText = GetComponent<Text>();
    }

    void Update ()
    {
        scoreText.text = checker.score.ToString();
        // scoreText.text = checker.time;
    }
}
