using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
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

    }
}
