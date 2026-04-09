using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public bool isVulnerable = false;

    private PatrolScript patrol;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        patrol = GetComponent<PatrolScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            isVulnerable = true;

            Destroy(collision.gameObject);

            StartCoroutine(StunBoss(10f));
        }
    }

    IEnumerator StunBoss(float duration)
    {
        // Oprim mișcarea
        if (patrol != null)
            patrol.enabled = false;

        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(duration);

        // Repornim mișcarea
        if (patrol != null)
            patrol.enabled = true;

        isVulnerable = false;
    }

    public void TakeDamage(int damage)
    {
        if (!isVulnerable)
            return;

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
