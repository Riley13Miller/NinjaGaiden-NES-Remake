using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] public float jumpHeight = 4f;
    private Rigidbody2D rb;
    private Animator anim;
    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Buttons();
        UpdateAnimations();
    }
    void Buttons()
    {
        float xCord = Input.GetAxis("Horizontal");
        float yCord = Input.GetAxis("Vertical");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //Debug.Log("isGrounded: " + isGrounded);

        if (isGrounded)
        {
            anim.SetInteger("State", 1);
            rb.linearVelocity = new Vector2(xCord * movementSpeed, rb.linearVelocity.y);

        }

        if (xCord > 0 && !facingRight)
            Flip();
        else if (xCord < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            //Debug.Log("Jumping");
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; // flip the X scale
        transform.localScale = scaler;
    }

    void UpdateAnimations()
    {
        if (!isGrounded)
        {
            anim.SetInteger("State", 2); // Jumping
        }
        else if (Mathf.Abs(rb.linearVelocity.x) > 0.1f)
        {
            anim.SetInteger("State", 1); // Running
        }
        else if(isGrounded && Mathf.Abs(rb.linearVelocity.x) < 0.1f)
        {
            anim.SetInteger("State", 0); // Idle
        }
    }
}
