using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text label;

    private bool isStarted = false;

    private int min, sec;
    private float cent;

    void Start()
    {
        GameEvents.current.onMainEmojiTouch += SetStart;
        GameEvents.current.onCheckerTriggerEnter += SetGameOver;

        min = 0;
        sec = 0;
        cent = 0f;
    }

    void Update () {
        if (isStarted) {
            cent += Time.deltaTime * 100;

            if (cent >= 99) {
                sec++;
                cent = 0;
            }

            label.text = sec.ToString("00") + ":" + cent.ToString("00");
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
    }

    private void SetGameOver ()
    {
        isStarted = false;
    }

}
