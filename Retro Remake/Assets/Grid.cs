using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Grid : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        generateGrid();
    }

    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;


    // Update is called once per frame
    void generateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                spawnedTile.name = $"Tile{x} {y}";


            }
        }
    }
}
