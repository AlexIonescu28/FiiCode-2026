using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    private bool firstFinish;
    private bool secondFinish;
    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        secondFinish = false;
        firstFinish = false;
        player1.GetComponent<Movement>().enabled = true;
        player2.GetComponent<Movement2>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
           
            if(collision.gameObject.name == "Player1 (BOL)" && firstFinish!=true)
            {
                player1.GetComponent<Movement>().enabled = false;
                firstFinish = true;
            }
            else
            {
                if (collision.gameObject.name == "Player2 (MOL)" && secondFinish!=true)
                {
                    player2.GetComponent<Movement2>().enabled = false;
                    secondFinish = true;
                }
            }
                     
        }


        if(firstFinish==true && secondFinish==true)
        {
            SceneManager.LoadSceneAsync(1);
            FindObjectOfType<timer>().SaveBestTime("Lvl1");
        }
    }
}
