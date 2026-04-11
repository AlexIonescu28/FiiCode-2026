using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    private SpriteRenderer sprite;
    private CircleCollider2D coll;
    private Vector3 initialScale;
    public Animator animator2;

    public bool isFacingRight = true;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask jumpableObject;

    public CollectibleObjectManager com;

    // Start is called before the first frame update
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        myRigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal2");
        myRigidbody.linearVelocity = new Vector2(directionX * 4, myRigidbody.linearVelocity.y);
        animator2.SetFloat("Speed2", Mathf.Abs(myRigidbody.linearVelocity.x));

        if (Input.GetButtonDown("Jump2") && GroundCheck())
        {
         
            myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocity.x, 4f);

            
            StartCoroutine(JumpAnimationRoutine());
        }

        UpdateAnimationUpdate(directionX);
    }

    private bool GroundCheck()
    {

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround | jumpableObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collectible object"))
        {
            Destroy(other.gameObject);
            com.ObjectCounter++;
        }
    }

    
    private void UpdateAnimationUpdate(float dirx)
    {
        if (dirx > 0f)
        {

            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
            isFacingRight = true;
        }
        else if (dirx < 0f)
        {

            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
            isFacingRight = false;
        }
    }

    private IEnumerator JumpAnimationRoutine()
    {
        animator2.SetBool("IsJumping2", true);

        // Așteptăm 0.5 secunde
        yield return new WaitForSeconds(0.5f);

        animator2.SetBool("IsJumping2", false);
    }
}