using UnityEngine;

public class BossProjectileAttack : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;   // proiectilul tău
    public Transform firePoint;           // locul de unde se aruncă proiectilul
    public float projectileSpeed = 10f;   // viteza în sus
    public float fireInterval = 2f;       // cât de des aruncă

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

        // instanțiem proiectilul
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // îi dăm viteză în sus
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.up * projectileSpeed;
        }
    }
}
