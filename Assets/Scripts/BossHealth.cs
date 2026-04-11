using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animatorboss;

    public HealthBar healthBar;

    public bool isVulnerable = false;      // poate fi lovit DOAR când e true
    public float postHitStunTime = 10f;    // timp de invulnerabilitate după ce e lovit

    private PatrolScript patrol;
    private Rigidbody2D rb;
    public BossHitEvents bossHitEvents;

    private bool isInPostHitStun = false;  // boss-ul a fost lovit și e în cooldown
    public GameObject objectToSpawnOnDeath;
    public GameObject[] lootItems;
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
            animatorboss.SetBool("Knocked", true);

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
        animatorboss.SetBool("Knocked", false);
    }

    public void TakeDamage(int damage)
    {
        if (!isVulnerable)
            return;

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (bossHitEvents != null)
            bossHitEvents.RegisterHit();

        StartCoroutine(PostHitStun(postHitStunTime));

        isVulnerable = false;

        if (currentHealth <= 0)
        {
            if (objectToSpawnOnDeath != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 offset = new Vector3(
                        UnityEngine.Random.Range(-1f, 1f),
                        UnityEngine.Random.Range(-1f, 1f),
                        0
                    );

                    Instantiate(objectToSpawnOnDeath, transform.position + offset, Quaternion.identity);
                }
            }

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
