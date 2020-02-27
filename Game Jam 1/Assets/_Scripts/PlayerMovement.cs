using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float JumpForce = 400f;                            // Amount of force added when the player jumps.
    [SerializeField] private LayerMask groundLayer;							// A mask determining what is ground to the character
    [SerializeField] private float speed = 4f;
    //[SerializeField] private CapsuleCollider2D capsule;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius;
    

    private Rigidbody2D rigidBody2d;
    private bool FacingRight = true;                                            // For determining which way the player is currently facing.
    private float moveHorizontal;
    private bool isTouchingGround;
    private bool jump;

    private void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
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
   
    void Start()
    {
        rigidBody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        //JumpVector = new Vector2(0f, JumpForce);
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log(moveHorizontal);
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }


    void FixedUpdate()
    {
        Debug.Log(isTouchingGround.ToString());

        if (moveHorizontal > 0f && !FacingRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0f && FacingRight)
        {
            Flip();
        }

        rigidBody2d.velocity = new Vector2(moveHorizontal * speed * Time.fixedDeltaTime, rigidBody2d.velocity.y);
        if (!isTouchingGround)
        {
            jump = false;
        }
        if(jump && isTouchingGround)
        {
            rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, JumpForce);
            jump = false;
        }
    }
}
