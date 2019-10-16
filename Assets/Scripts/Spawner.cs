using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;

    [Slider(0f, 20f)]
    public float fireSpeed;

    [Slider(1f, 10f)]
    public float fireRate;

    [Dropdown("vectorDir")]
    public Vector2 shootDirection;

    private float nextSpawn = 0f;
    private DropdownList<Vector2> vectorDir = new DropdownList<Vector2>()
    {
        { "Up", Vector2.up },
        { "Down", Vector2.down },
        { "Right", Vector2.right },
        { "Left", Vector2.left },
        { "None", Vector2.zero },
    };

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true) {
            int idx = Random.Range(0, prefabs.Count);
            GameObject obj = Instantiate(
                prefabs[idx], transform.position, Quaternion.identity
            ) as GameObject;
            obj.GetComponent<Rigidbody2D>().velocity = shootDirection * fireSpeed;
            yield return new WaitForSeconds(1 / fireRate);
        }
    }
}
