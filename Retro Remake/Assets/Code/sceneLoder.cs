using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    
    public void LoadScene(string retro)
    {
        SceneManager.LoadScene(retro);
        TetrisBlock.score = 0;
    }
}
