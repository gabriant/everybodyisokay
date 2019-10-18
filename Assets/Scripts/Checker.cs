using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Checker : MonoBehaviour
{
    public int score;

    private BoxCollider2D area;

    void Awake ()
    {
        area = GetComponent<BoxCollider2D>();
        // score = 0;
    }

    // void Update()
    // {
    //     Debug.Log(area.IsTouching());
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        Emoji emoji = other.GetComponent<Emoji>();
        score += emoji.value;
    }

}
