using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMPro.TMP_Text _title;

    void Update()
    {
        _title.SetText( "score" + TetrisBlock.score.ToString());
    }
}
