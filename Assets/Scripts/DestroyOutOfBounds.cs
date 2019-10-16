using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField]
    private float margin = 1.5f;

    private Vector2 screenBounds;

    void Awake ()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(
            Screen.width, Screen.height
        ));
    }

    void Update ()
    {
        if (transform.position.y < -screenBounds.y * margin
            || transform.position.y > screenBounds.y * margin
            || transform.position.x < -screenBounds.x * margin
            || transform.position.x > screenBounds.x * margin
        ) { Destroy(this.gameObject); }
    }
}
