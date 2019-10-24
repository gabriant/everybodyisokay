using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NaughtyAttributes;

public class GameManager : MonoBehaviour
{
    public Text label;
    public Spawner spawner;

    [Slider(1f, 100f)]
    public int multiplier;

    private bool isStarted = false;
    private float score;
    private float highscore;

    void Start()
    {
        GameEvents.current.onMainEmojiTouch += SetStart;
        GameEvents.current.onCheckerTriggerEnter += SetGameOver;

        score = 0f;
        highscore = PlayerPrefs.GetFloat("highscore", score);
    }

    void Update () {
        if (isStarted) {
            score += Time.deltaTime * multiplier;
            label.text = score.ToString("00");
        }
    }

    private void OnDestroy ()
    {
        GameEvents.current.onMainEmojiTouch -= SetStart;
        GameEvents.current.onCheckerTriggerEnter -= SetGameOver;
    }

    private void SetStart ()
    {
        isStarted = true;
        spawner.TurnOn();
    }

    private void SetGameOver ()
    {
        isStarted = false;
        spawner.TurnOff();
        SetHighscore();
        SceneManager.LoadScene("GameOver");
    }

    public void restartGame ()
    {
        SceneManager.LoadScene("Game");
    }

    private void SetHighscore ()
    {
        if (score > highscore) {
            PlayerPrefs.SetFloat("highscore", score);
        }
    }

}
