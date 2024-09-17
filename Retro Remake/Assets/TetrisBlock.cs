using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Rotate;
    public KeyCode Fall;
    private float previousTime;
    public float fallTime = 0.8f;
    //public KeyCode Rotate;
    // public KeyCode drop;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Left))
        {
            transform.position += new Vector3(-1, 0, 0);
        }

        else if (Input.GetKeyDown(Right))
        {
            transform.position += new Vector3(1, 0, 0);
        }

        if (Time.time - previousTime > (Input.GetKey(Fall) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            previousTime = Time.time;
        }
        
    }
}