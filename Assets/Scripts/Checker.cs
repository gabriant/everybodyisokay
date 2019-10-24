using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Checker : MonoBehaviour
{
    // public int score;
    private BoxCollider2D area;

    void Awake ()
    {
        area = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "MainEmoji") {
            GameEvents.current.CheckerTriggerEnter();
            Debug.Log("Game Over!");
        }
    }


}
