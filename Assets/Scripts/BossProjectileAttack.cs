using UnityEngine;

public class BossProjectileAttack : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;   
    public Transform firePoint;           
    public float projectileSpeed = 10f;   
    public float fireInterval = 2f;      

    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            FireProjectile();
            fireTimer = 0f;
        }
    }

    void FireProjectile()
    {
        if (projectilePrefab == null || firePoint == null)
            return;

       
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

      
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.up * projectileSpeed;
        }
    }
}
