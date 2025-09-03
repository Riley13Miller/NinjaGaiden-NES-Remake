using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    private PlayerMovement movement;
    public Transform wallCheck;
    public float wallCheckDistance = 0.1f;
    public LayerMask wallLayer;
    public float wallJumpForce = 4f;
    private bool isWallGrabbing;
    //private bool isTouchingWall;
    private float normalGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        normalGravity = rb.gravityScale;
        anim = GetComponent<Animator>();
        
    }
    void Update()
    {
        CheckWall();
        HandleWallCling();
        WallJump();
    }

    void CheckWall()
    {
        isWallGrabbing = Physics2D.Raycast(wallCheck.position, transform.right * Mathf.Sign(transform.localScale.x), wallCheckDistance, wallLayer);

        if (isWallGrabbing && !movement.isGrounded)
        {
            isWallGrabbing = true;
            anim.SetInteger("State", 3); // Wall Cling Animation
        }
        else
        {
            isWallGrabbing = false;
        }
    }

    void WallJump()
    {
        if (Input.GetButtonDown("Jump") && isWallGrabbing)
        {
            isWallGrabbing = false;
            rb.gravityScale = normalGravity;
            rb.linearVelocity = Vector2.zero;
            float jumpDirection = -Mathf.Sign(transform.localScale.x); // jump opposite to facing direction
            rb.AddForce(new Vector2(jumpDirection * wallJumpForce, movement.jumpHeight), ForceMode2D.Impulse);

            Vector3 scale = transform.localScale;
            scale.x = jumpDirection * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

     void HandleWallCling()
    {
        if (isWallGrabbing)
        {
            rb.linearVelocity = Vector2.zero;  
            rb.gravityScale = 0;         
        }
        else
        {
            rb.gravityScale = normalGravity;
        }
    }
}
