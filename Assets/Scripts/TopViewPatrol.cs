using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;
    public Rigidbody2D enemyRigidBody;
    private Transform currentPosition;
    private SpriteRenderer sprite;
    public float speed;


    public bool isFacingRight = true;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemyRigidBody = GetComponent<Rigidbody2D>();
        currentPosition = pointB.transform;
    }


    void Update()
    {

        Vector2 point = currentPosition.position - transform.position;
        if (currentPosition == pointB.transform)
        {
            enemyRigidBody.linearVelocity = new Vector2(speed, 0);
        }

        if (currentPosition == pointC.transform)
        {
            enemyRigidBody.linearVelocity = new Vector2(0, -speed);
        }

        if (currentPosition == pointD.transform)
        {
            enemyRigidBody.linearVelocity = new Vector2(-speed, 0);
        }

        if (currentPosition == pointA.transform)
        {
            enemyRigidBody.linearVelocity = new Vector2(0, speed);
        }


        if (Vector2.Distance(transform.position, currentPosition.position) < 0.5f && currentPosition == pointB.transform)
        {
            currentPosition = pointC.transform;
        }

        if (Vector2.Distance(transform.position, currentPosition.position) < 0.5f && currentPosition == pointC.transform)
        {
            currentPosition = pointD.transform;
        }

        if (Vector2.Distance(transform.position, currentPosition.position) < 0.5f && currentPosition == pointD.transform)
        {
            currentPosition = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPosition.position) < 0.5f && currentPosition == pointA.transform)
        {
            currentPosition = pointB.transform;
        }

        UpdateAnimationUpdate(point.x);

    }

    private void UpdateAnimationUpdate(float dirx)
    {
        if (dirx > 0f)
        {
            sprite.flipX = false;
            isFacingRight = true;
        }
        else if (dirx < 0f)
        {
            sprite.flipX = true;
            isFacingRight = false;
        }
    }
}
