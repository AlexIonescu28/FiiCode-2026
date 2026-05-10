using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMoving : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 input;
    public CollectibleObjectManager com;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        
        if (input != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("InputX", input.x);
            animator.SetFloat("InputY", input.y);
            animator.SetFloat("LastInputX", input.x);
            animator.SetFloat("LastInputY", input.y);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collectible object"))
        {
            Destroy(other.gameObject);
            com.ObjectCounter++;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
}