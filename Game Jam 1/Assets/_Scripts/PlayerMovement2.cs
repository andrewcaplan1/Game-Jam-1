using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] float jumpVelocity = 30f;                          //Jump force/how high the ghost jumps
    [SerializeField] float moveSpeed = 20f;                             //How fast the ghost moves
    [SerializeField] float midAirControl = 3f;                          //How fast the ghost can change velocity in mid air

    [SerializeField] private Transform respawnPoint;
    [HideInInspector] public bool onDeath;
    private float moveHorizontal;
    private bool FacingRight = true;                                    // For determining which way the player is currently facing

    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    public GameObject shooter;
    public Sprite unveiled;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        HandleMovement();
    }

    private void FixedUpdate()
    {
        Debug.Log(IsGrounded().ToString());

        if (moveHorizontal > 0f && !FacingRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0f && FacingRight)
        {
            Flip();
        }

        onDeath = false;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        return raycastHit2d.collider != null;
    }

    private void HandleMovement()
    {
        if (moveHorizontal < 0)
        {
            if (IsGrounded())
            {
                rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            }
            else
            {
                rigidbody2d.velocity += new Vector2(-moveSpeed * midAirControl * Time.deltaTime, 0);
                rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -moveSpeed, +moveSpeed), rigidbody2d.velocity.y);
            }
        }
        else
        {
            if (moveHorizontal > 0)
            {
                if (IsGrounded())
                {
                    rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
                }
                else
                {
                    rigidbody2d.velocity += new Vector2(+moveSpeed * midAirControl * Time.deltaTime, 0);
                    rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -moveSpeed, +moveSpeed), rigidbody2d.velocity.y);
                }
            }
            else
            {
                if (IsGrounded())
                {
                    rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                }
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die(collision.gameObject);
        }
    }

    void Die(GameObject collisionObject)
    {
        onDeath = true;
        transform.position = respawnPoint.position;
        rigidbody2d.Sleep();
        SpriteRenderer Srend = collisionObject.GetComponent<SpriteRenderer>();
        Srend.enabled = true;
        LevelEndText.scoreValue++;
    }
}
