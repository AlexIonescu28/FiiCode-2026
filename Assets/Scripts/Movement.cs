using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Vector3 initialScale;
    public bool isFacingRight = true;
    public CollectibleObjectManager com;
    private bool canDoubleJump;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask jumpableObject;

    // Start is called before the first frame update
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        myRigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        myRigidbody.linearVelocity = new Vector2(directionX * 7, myRigidbody.linearVelocity.y);

        
        if (GroundCheck())
        {
            canDoubleJump = true;
        }

      
        if (Input.GetButtonDown("Jump"))
        {
            if (GroundCheck())
            {
              
                myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocity.x, 7f);
            }
            else if (canDoubleJump)
            {
               
                myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocity.x, 7f);

               
                canDoubleJump = false;
            }
        }

        UpdateAnimationUpdate(directionX);
    }

    private bool GroundCheck()
    {
        
        Vector2 origin = new Vector2(coll.bounds.center.x, coll.bounds.min.y);

        Vector2 boxSize = new Vector2(coll.bounds.size.x * 0.9f, 0.1f);

     
        return Physics2D.BoxCast(origin, boxSize, 0f, Vector2.down, 0.1f, jumpableGround | jumpableObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("collectible object"))
        {
            Destroy(other.gameObject);
            com.ObjectCounter ++;
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
}
