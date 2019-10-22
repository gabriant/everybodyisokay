using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerB : MonoBehaviour
{
    public int speed = 5;

    void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, speed, Space.Self);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, -speed, Space.Self);
        }
    }
}
