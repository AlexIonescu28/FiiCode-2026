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

    [SerializeField] private LayerMask jumpableGround;

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

        myRigidbody.velocity = new Vector2(directionX * 7, myRigidbody.velocity.y);

        if (Input.GetButtonDown("Jump") && GroundCheck())
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 7f);
        }

        UpdateAnimationUpdate(directionX);
    }

    private bool GroundCheck()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
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
