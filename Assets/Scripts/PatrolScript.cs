using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public Rigidbody2D enemyRigidBody;
    private Transform currentPosition;
    private SpriteRenderer sprite;
    public float speed;
    public bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemyRigidBody = GetComponent<Rigidbody2D>();
        currentPosition = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPosition.position - transform.position;
        if(currentPosition==pointB.transform)
        {
            enemyRigidBody.velocity = new Vector2(speed,0);
        }
        else
        {
            enemyRigidBody.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position,currentPosition.position) < 0.5f && currentPosition==pointB.transform)
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
