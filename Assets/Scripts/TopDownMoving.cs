using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TopDownMoving : MonoBehaviour
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

        if (Input.GetKey(KeyCode.UpArrow))
            input.y = 1;
        else if (Input.GetKey(KeyCode.DownArrow))
            input.y = -1;

        if (Input.GetKey(KeyCode.RightArrow))
            input.x = 1;
        else if (Input.GetKey(KeyCode.LeftArrow))
            input.x = -1;

        input.Normalize(); 
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
}
