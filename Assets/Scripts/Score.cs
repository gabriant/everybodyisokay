using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    void Awake ()
    {
        scoreText = GetComponent<Text>();
    }

    void Start ()
    {
        GameEvents.current.onMainEmojiTouch += SetStart;
        GameEvents.current.onCheckerTriggerEnter += SetGameOver;
    }

    private void SetStart ()
    {
        scoreText.text = "Started!";
    }

    private void SetGameOver ()
    {
        scoreText.text = "Game Over!";
    }

    private void OnDestroy ()
    {
        GameEvents.current.onMainEmojiTouch -= SetStart;
        GameEvents.current.onCheckerTriggerEnter -= SetGameOver;
    }

    // void Update ()
    // {
    //     // scoreText.text = checker.score.ToString();
    //     // scoreText.text = checker.time;
    // }
}
