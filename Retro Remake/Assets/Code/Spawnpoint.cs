using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject[] spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    public void Spawn()
    {
        Instantiate(spawnpoint[Random.Range(0, spawnpoint.Length)], transform.position, Quaternion.identity);
    }
}
