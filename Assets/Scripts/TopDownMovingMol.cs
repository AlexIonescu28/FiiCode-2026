using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovingMol : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 input;
    public CollectibleObjectManager com;
    private Animator animator2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator2 = GetComponent<Animator>();
    }

    void Update()
    {
        input = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            input.y = 1;
        else if (Input.GetKey(KeyCode.S))
            input.y = -1;

        if (Input.GetKey(KeyCode.D))
            input.x = 1;
        else if (Input.GetKey(KeyCode.A))
            input.x = -1;

        input.Normalize();

        if (input != Vector2.zero)
        {
            animator2.SetBool("isWalking2", true);
            animator2.SetFloat("InputX2", input.x);
            animator2.SetFloat("InputY2", input.y);

            animator2.SetFloat("LastInputX2", input.x);
            animator2.SetFloat("LastInputY2", input.y);
        }
        else
        {
            animator2.SetBool("isWalking2", false);
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