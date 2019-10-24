using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Rigidbody2D body;

    void Awake ()
    {
        body = GetComponent<Rigidbody2D>();
    }


    // Trigger when emoji touches the platform
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MainEmoji") {
            GameEvents.current.MainEmojiTouch();
            Debug.Log("Start!");
        }
    }
}
