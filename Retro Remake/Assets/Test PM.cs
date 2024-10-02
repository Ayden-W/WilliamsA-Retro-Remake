using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public int score, numberOfItems;    // Ints represent WHOLE NUMBERS
    public float Health, Weight, Speed; // Ints represent DECIMAL NUMBERS
    public string menuLabel, dialogue, characterName;    // Strings represent WORDS/PHRASES/TEXT
    public bool isEnemyDead, isEffective, isGrounded, isPlayerDead;    // Btools represent values are TRUE OR FALSE
    public Vector2 size, playerlocation;  // Vestor2s represent 2-DIMENSIONAL DECIMALS
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The person I don't like is" + characterName);

        if (isGrounded) // Will execute the below code IF THE STATEMENT IN THE PARENTHESIS IS CURRENTLY TRUE
        {
            Debug.Log("YOW");
        }
        else { Debug.Log("Just kidding I actually don't like this person" + ("Hahaha")); }  // Code in the Else will execute if the code in the IF DID NOT EXECUTE
    }


    // Update is called once per frame
    void Update()
    {

    }
}
