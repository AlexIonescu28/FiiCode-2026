using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrolScript : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Rigidbody2D enemyRigidBody;
    private Transform targetPoint;
    private SpriteRenderer sprite;
    public float speed;
    public bool isFacingRight = true;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemyRigidBody = GetComponent<Rigidbody2D>();
        targetPoint = pointB;
    }

    void Update()
    {
        // Direc?ia spre punctul ?int?
        float direction = Mathf.Sign(targetPoint.position.x - transform.position.x);

        // Mi?care
        enemyRigidBody.linearVelocity = new Vector2(direction * speed, 0);

        // Dac? boss-ul a trecut de punct, schimb? direc?ia
        if (direction > 0 && transform.position.x >= pointB.position.x)
        {
            targetPoint = pointA;
        }
        else if (direction < 0 && transform.position.x <= pointA.position.x)
        {
            targetPoint = pointB;
        }

        UpdateSprite(direction);
    }

    private void UpdateSprite(float dir)
    {
        if (dir > 0)
        {
            sprite.flipX = false;
            isFacingRight = true;
        }
        else if (dir < 0)
        {
            sprite.flipX = true;
            isFacingRight = false;
        }
    }
}
