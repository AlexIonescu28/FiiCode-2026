using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovingMol : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.x = 0;
        input.y = 0;

        if (Input.GetKey(KeyCode.W))
            input.y = 1;
        else if (Input.GetKey(KeyCode.S))
            input.y = -1;

        if (Input.GetKey(KeyCode.D))
            input.x = 1;
        else if (Input.GetKey(KeyCode.A))
            input.x = -1;

        input.Normalize();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
}
