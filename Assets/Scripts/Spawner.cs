using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objects;

    [Slider(0.1f, 4f)]
    public float objScale = 1f;

    [Slider(0.1f, 20f)]
    public float objSpeed;

    [Slider(1f, 10f)]
    public float objPerSecond = 1f;

    [Dropdown("vectorDir")]
    public Vector2 direction;

    public bool isOn;

    private DropdownList<Vector2> vectorDir = new DropdownList<Vector2>()
    {
        { "Up", Vector2.up },
        { "Down", Vector2.down },
        { "Right", Vector2.right },
        { "Left", Vector2.left },
        { "None", Vector2.zero },
    };

    public void TurnOn ()
    {
        if (!isOn) {
            isOn = true;
            StartCoroutine(Spawn());
            Debug.Log("Lavai");
        }
    }

    public void TurnOff ()
    {
        if (isOn) {
            isOn = false;
            Debug.Log("Parou");
        }
    }

    IEnumerator Spawn()
    {
        while (isOn){
            int idx = Random.Range(0, objects.Count);
            GameObject obj = Instantiate(
                objects[idx], transform.position, Quaternion.identity
            ) as GameObject;
            obj.GetComponent<Rigidbody2D>().velocity = direction * objSpeed;
            obj.transform.localScale = new Vector3(objScale, objScale, objScale);

            yield return new WaitForSeconds(1 / objPerSecond);
        }
    }
}
