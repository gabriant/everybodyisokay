using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilter : MonoBehaviour
{
    public Rigidbody2D body;

    void Awake ()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void StartTimer ()
    {
        Debug.Log(Time.deltaTime);
    }

    // Trigger when emoji touches the tilter
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MainEmoji") {
            GameEvents.current.MainEmojiTouch();
            Debug.Log("Start!");
        }
    }
}
