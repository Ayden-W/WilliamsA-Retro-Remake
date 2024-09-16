using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCode : MonoBehaviour
{
    int score;
    bool GameOver;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Rotate;
    public KeyCode drop;
    // Start is called before the first frame update
    void Start()
    {
        int score = 0;
        GameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Left))
        {
            transform.position +=


        }
    }
}
