using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public bool isVulnerable = false;      // poate fi lovit DOAR când e true
    public float postHitStunTime = 10f;    // timp de invulnerabilitate după ce e lovit

    private PatrolScript patrol;
    private Rigidbody2D rb;

    private bool isInPostHitStun = false;  // boss-ul a fost lovit și e în cooldown

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
        if (patrol != null)
            patrol.enabled = false;

        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(duration);

        if (patrol != null)
            patrol.enabled = true;

        isVulnerable = false;
    }

    public void TakeDamage(int damage)
    {
        // NU poate fi lovit dacă:
        // - nu este vulnerabil
        // - este în cooldown după ce a fost lovit
        if (!isVulnerable || isInPostHitStun)
            return;

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // pornește cooldown-ul de invulnerabilitate
        StartCoroutine(PostHitStun(postHitStunTime));

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator PostHitStun(float duration)
    {
        isInPostHitStun = true;
        isVulnerable = false; // nu mai poate fi lovit în acest timp

        yield return new WaitForSeconds(duration);

        isInPostHitStun = false;
        // vulnerabilitatea NU se reactivează automat
        // doar trap-ul îl face vulnerabil din nou
    }
}
