using UnityEngine;

public class ArrowDispenser : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public Transform targetPoint;
    public float shootForce = 10f;
    public float interval = 1.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            ShootArrow();
            timer = 0f;
        }
    }

    void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        Vector2 direction = (targetPoint.position - shootPoint.position).normalized;

        rb.linearVelocity = direction * shootForce;

   
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
