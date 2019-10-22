    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using NaughtyAttributes;

    public class Checker : MonoBehaviour
    {
        public int score;
        // public string time;

        private BoxCollider2D area;
        // private float startTime;
        // private bool count = true;

        void Awake ()
        {
            area = GetComponent<BoxCollider2D>();
            // score = 0;
        }

    // void Start ()
    // {
    //     startTime = Time.time;
    // }

    // void Update()
    // {
    //     if (count) {

    //         float t = Time.time - startTime;

    //         string min = ((int) t/60).ToString();
    //         string sec = (t%60).ToString("f2");

    //         time = min + ":" + sec;
    //     }
    // }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "MainEmoji")
        {
            GameEvents.current.CheckerTriggerEnter();
            Debug.Log("Game Over!");
        }
    }


}
