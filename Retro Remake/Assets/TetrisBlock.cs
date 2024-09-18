using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    public KeyCode Left;
    public KeyCode Right;
    public  Vector3 RotationPoint;
    public KeyCode Fall;
    private float _previousTime;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 30;
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
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }

        else if (Input.GetKeyDown(Right))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.R))
            {
            //rotate
            transform.Rotate(0, 0, 90, Space.Self);
            if (!ValidMove()) {
                transform.Rotate(0,0,-90);
            }
            }
        if (Time.time - _previousTime > (Input.GetKey(Fall) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
            }

            _previousTime = Time.time;

        }
    }

    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < -4 || roundedX > 5 || roundedX >= width || roundedY < -10 || roundedY >= height)
            {
                return false;
            }
        }

        return true;
    }
}