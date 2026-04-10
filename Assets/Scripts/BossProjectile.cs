using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    private string[] destroyTags =
    {
        "BossDestructibleObject",
        "BossDestructibleObject2",
        "BossDestructibleObject3",
        "Trap"
    };

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // proiectilul merge în sus
            rb.linearVelocity = Vector2.up * speed;
        }

        // se distruge automat după un timp
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in destroyTags)
        {
            if (collision.CompareTag(tag))
            {
                Destroy(gameObject);
                return;
            }
        }
    }
}
