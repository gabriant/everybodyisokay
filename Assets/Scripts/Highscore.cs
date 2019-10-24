using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text label;
    private float highscore;

    void Start()
    {
        label = GetComponent<Text>();
        highscore = PlayerPrefs.GetFloat("highscore", 0f);
        label.text = ("Highscore " + highscore).ToString();
    }

}
