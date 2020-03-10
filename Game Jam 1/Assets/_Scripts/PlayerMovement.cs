using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float JumpForce = 400f;                            // Amount of force added when the player jumps.
    [SerializeField] private LayerMask groundLayer;							// A mask determining what is ground to the character
    [SerializeField] private float speed = 4f;
    //[SerializeField] private CapsuleCollider2D capsule;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject levelSelector;
    [SerializeField] private bool isTouchingGround;
    [SerializeField] private float restrictMovement = 1f;

    [HideInInspector] public bool onDeath;

    public List<Vector3> deathLocations;

    private LevelSelector levelSelectorScript;
    private Rigidbody2D rigidBody2d;
    private bool FacingRight = true;                                            // For determining which way the player is currently facing.
    private float moveHorizontal;

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
        levelSelectorScript = levelSelector.GetComponent<LevelSelector>();
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        Debug.Log(isTouchingGround.ToString());

        //flip
        if (moveHorizontal > 0f && !FacingRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0f && FacingRight)
        {
            Flip();
        }

        rigidBody2d.velocity = new Vector2(moveHorizontal * speed * restrictMovement * Time.fixedDeltaTime, rigidBody2d.velocity.y);

        if (!isTouchingGround)
        {
            jump = false;
        }
        if (isTouchingGround)
        {
            restrictMovement = 1f;
            if (jump)
            {
                rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, JumpForce);
                jump = false;
            }

        }

        Debug.Log(deathLocations);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die(collision.gameObject);
        } else if (collision.CompareTag("WinLevel"))
        {
            Debug.LogError(collision.name);
            string colliderName = collision.name;
            colliderName = colliderName.Remove(colliderName.Length - 6);
            levelSelectorScript.PrepareNextLevel(colliderName);
        }
    }

    void Die(GameObject collisionObject)
    {
        restrictMovement = 0f;
        onDeath = true;
        deathLocations.Add(transform.position);
        transform.position = respawnPoint.position;
        Renderer rend = collisionObject.GetComponent<Renderer>();
        rend.enabled = true;
        LevelEndText.scoreValue++;
    }

    public void Die()
    {
        restrictMovement = 0f;
        onDeath = true;
        deathLocations.Add(transform.position);
        transform.position = respawnPoint.position;
        LevelEndText.scoreValue++;
    }
}
