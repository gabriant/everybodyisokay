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

    public GameObject mainEmoji;

    void Start()
    {
        GameEvents.current.onMainEmojiTouch += SetStart;
        GameEvents.current.onCheckerTriggerEnter += SetGameOver;
        // mainEmoji = GameObject.FindGameObjectWithTag("MainEmoji");

        score = 0f;
        highscore = PlayerPrefs.GetFloat("highscore", score);
    }

    void Update () {
        if (isStarted) {
            score += Time.deltaTime * multiplier;
            label.text = score.ToString("0");
        }

        if (Input.GetKeyUp(KeyCode.Space))
            RestartGame();

    }

    // void FixedUpdate () {
    //     float scale = score/100000;
    //     // if (score > 300)
    //     mainEmoji.transform.localScale -= new Vector3(scale, scale, scale);
    // }

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

        if (score > highscore)
            SetHighscore(score);

        SceneManager.LoadScene("GameOver");
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene("Game");
    }

    private void SetHighscore (float score)
    {
        PlayerPrefs.SetFloat("highscore", score);
    }

    [Button("Reset Highscore")]
    private void ResetHighscore () {
        SetHighscore(0);
    }

}
