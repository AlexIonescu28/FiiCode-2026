using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    private bool firstFinish;
    private bool secondFinish;

  

    void Start()
    {
        secondFinish = false;
        firstFinish = false;

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("player"))
        {
            
            if (collision.gameObject.name.Contains("Player1") && firstFinish == false)
            {
              
                collision.GetComponent<Movement>().enabled = false;
                firstFinish = true;
            }
            else if (collision.gameObject.name.Contains("Player2") && secondFinish == false)
            {
               
                collision.GetComponent<Movement2>().enabled = false;
                secondFinish = true;
            }
        }

        
        if (firstFinish == true && secondFinish == true)
        {
            FindObjectOfType<timer>().SaveBestTime(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            SceneManager.LoadSceneAsync(1);
            enabled = false;
        }
    }
}