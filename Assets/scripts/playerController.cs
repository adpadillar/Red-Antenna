using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private float movementInputDirection;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    public float movementSpeed = 10.0f;
    public float jumpForce = 16.0f;
    public int coins = 0;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    private bool isGrounded;
    private int availableJumps = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // set the ground check position to the player's feet
        groundCheck = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
        checkMovementDirection();
        CheckSurroundings();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 1f, whatIsGround);
        if (isGrounded) {
            availableJumps = 2;
        }
    }

    private void checkMovementDirection()
    {
        if (isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }
    }

    private void checkInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isGrounded || availableJumps > 0) {
            availableJumps--;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 1f);
    }
}
