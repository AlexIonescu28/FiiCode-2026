using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPoint;
    public float radius;
    public LayerMask enemies;
    public LayerMask destructibleObjects;
    public LayerMask bossLayer;
    public Animator animator2;

    
    public float attackDuration = 0.5f;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            
            StartCoroutine(AttackRoutine());
        }
    }

    
    IEnumerator AttackRoutine()
    {
        
        animator2.SetBool("Attack", true);

        
        Collider2D[] taged = Physics2D.OverlapCircleAll(attackPoint.position, radius, enemies);
        Collider2D[] destroyed = Physics2D.OverlapCircleAll(attackPoint.position, radius, destructibleObjects);
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, radius);

        foreach (Collider2D enemy in taged)
        {
            Destroy(enemy.gameObject);
            Debug.Log("Inamicul " + enemy.name + " a fost distrus instantaneu!");
        }

        foreach (Collider2D objects in destroyed)
        {
            Destroy(objects.gameObject);
            Debug.Log("Obiectul " + objects.name + " a fost distrus instantaneu!");
        }

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("boss"))
            {
                BossHealth bh = hit.GetComponent<BossHealth>();
                if (bh != null)
                {
                    bh.TakeDamage(1);
                    Debug.Log("Boss-ul a primit damage!");
                }
            }
        }

        
        yield return new WaitForSeconds(0.5f);

        
        animator2.SetBool("Attack", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}