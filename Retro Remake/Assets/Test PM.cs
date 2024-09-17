using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPM : MonoBehaviour
{
    public int numberOfItems, Score;        // ints == whole Numbers
    public float Health, Weight, Speed;     //Floats == Decimal Numbers
    public string MenuLabel, CharacterName; // Strings == Words/Phrases/text
    public bool Jump;                       //Bools == values that are True Or False
    public Vector2 size, PlayerLocation;    //Vector2s == 2-dimensional Decimals
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Derek's Favorite Student is" + CharacterName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
