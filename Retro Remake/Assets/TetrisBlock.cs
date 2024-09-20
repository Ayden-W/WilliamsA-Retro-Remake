using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TetrisBlock : MonoBehaviour
{
    public KeyCode Left;
    public KeyCode Right;
    public  Vector3 RotationPoint;
    public KeyCode Fall;
    public KeyCode Rotate;
    public static double height = 13.00198;
    public static double width = 21.28693;
    private float _previousTime;
    public float fallTime = 0.8f;
    private bool can_move = true;
    private static Transform[,] grid = new Transform[width,height];

    

    public Rect bounds;
    //public KeyCode Rotate;
    // public KeyCode drop;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (can_move)
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

            else if (Input.GetKeyDown(Rotate))
            {
                //rotate
                transform.Rotate(0, 0, 90, Space.Self);
                if (!ValidMove())
                {
                    transform.Rotate(0, 0, -90, Space.Self);
                }
            }
            if (Time.time - _previousTime > (Input.GetKey(Fall) ? fallTime / 10 : fallTime))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);
                    this.enabled = false;
                    FindObjectOfType<Spawnpoint>().Spawn();
                }

                _previousTime = Time.time;
            }
        }
    }

    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            

            if(!bounds.Contains(new Vector2Int(roundedX, roundedY)))
            {
                return false;
            }
        }

        return true;
    }
}