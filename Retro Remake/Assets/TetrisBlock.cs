using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TetrisBlock : MonoBehaviour
{
    public KeyCode Left;
    public KeyCode Right;
    public  Vector3 RotationPoint;
    public KeyCode Fall;
    public KeyCode Rotate;
    public static int height = 20;
    public static int width = 13;
    private float _previousTime;
    public float fallTime = 0.8f;
    private bool can_move = true;
    private static Transform[,] grid = new Transform[width, height];
    public int score;
    

    

    public Rect bounds;
    //public KeyCode Rotate;
    // public KeyCode drop;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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
                    AddToGrid();
                    CheckForLines();

                    this.enabled = false;
                    FindObjectOfType<Spawnpoint>().Spawn();
                }

                _previousTime = Time.time;
            }
        }
    }

    void CheckForLines()
    {
        for(int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                deleteLine(i);
                RowDown(i);
                score = score + 50;
            }
        }
    }

   
    bool HasLine(int i)
    {
        for (int j = 0; j < width ; j++)
        {
            if (grid[j,i] == null) 
                return false;
        }
        return true;
    }


    //Remove line
    void deleteLine(int i)
    {
        for(int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }


    //move the row down
    void RowDown(int i)
    {
        for (int y=i; y< height; y++)
        {
            for(int j = 0; j< width; j++) 
            { 
            if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
    

    void GameOver()
    {
        
    }




    void AddToGrid()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }
    

    //Able to move
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

            if (grid[roundedX, roundedY] != null)
                return false;
        }

        return true;
    }
}