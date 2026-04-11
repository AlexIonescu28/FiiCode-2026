using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public Rigidbody2D otherRigidbody;
    public Animator animator;
    public Animator animator2;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || 
            collision.gameObject.CompareTag("Enemy") || 
            collision.gameObject.CompareTag("Projectile") || 
            collision.gameObject.CompareTag("boss"))
        {
            Die();
            StartCoroutine(RestartLevelWithDelay(2f));
        }
    }

    private void Die()
    {
        if (myRigidbody.gameObject.name == "Player1")
        {
            myRigidbody.GetComponent<Movement>().enabled = false;
            animator.SetTrigger("Death");
        }
        else if (myRigidbody.gameObject.name == "Player2") 
        {
            myRigidbody.GetComponent<Movement2>().enabled = false;
            animator2.SetTrigger("Death2");
        }

        if (otherRigidbody.gameObject.name == "Player1")
        {
            otherRigidbody.GetComponent<Movement>().enabled = false;
        }
        else if (otherRigidbody.gameObject.name == "Player2")
        {
            otherRigidbody.GetComponent<Movement2>().enabled = false;
        }
    }

    private IEnumerator RestartLevelWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}