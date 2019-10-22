using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake ()
    {
        current = this;
    }

    public event Action onMainEmojiTouch;
    public void MainEmojiTouch ()
    {
        if (onMainEmojiTouch != null) {
            onMainEmojiTouch();
        }
    }

    public event Action onCheckerTriggerEnter;
    public void CheckerTriggerEnter ()
    {
        if (onCheckerTriggerEnter != null) {
            onCheckerTriggerEnter();
        }
    }
}
