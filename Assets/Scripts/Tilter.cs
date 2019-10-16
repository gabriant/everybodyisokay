using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilter : MonoBehaviour
{
    private Rigidbody2D body;
    private GameObject obj;

    void Awake ()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, 10, Space.Self);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, -10, Space.Self);
        }
    }
}
