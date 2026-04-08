using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public Rigidbody2D otherRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            RestartLevel();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            RestartLevel();
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Die();
            RestartLevel();
        }
        if (collision.gameObject.CompareTag("boss"))
        {
            Die();
            RestartLevel();
        }
    }

    private void Die()
    {
        
        //myRigidbody.bodyType = RigidbodyType2D.Static;

        if (myRigidbody.gameObject.name == "Player1")
        {
            myRigidbody.GetComponent<Movement>().enabled = false;
        }
        else if (myRigidbody.gameObject.name == "Player2") 
        {
            myRigidbody.GetComponent<Movement2>().enabled = false;
        }

       
        //otherRigidbody.bodyType = RigidbodyType2D.Static;

        if (otherRigidbody.gameObject.name == "Player1")
        {
            otherRigidbody.GetComponent<Movement>().enabled = false;
        }
        else if (otherRigidbody.gameObject.name == "Player2")
        {
            otherRigidbody.GetComponent<Movement2>().enabled = false;
        }

        // anim.SetTrigger("death"); 
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}