using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mob : Character
{


    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    public float dashSpeed = 1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    CapsuleCollider2D capsule;
    SpriteRenderer spriteRenderer;

    private Vector2 move;
    public bool doubleJump;

    public AnimationCurve jumpGravityCurve;
    public float maxJumpTime = 1f;
    private float jumpTime;

    private bool lookRight;


    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGrounded())
        {
            ApplyCurveGravity();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }


    void Jump()
    {
        if (IsGrounded() || doubleJump)
        {
            doubleJump = !doubleJump;
            jumpTime = 0f;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
    }

    void Move()
    {
        rb.velocity = new Vector2(move.x * moveSpeed, rb.velocity.y);
    }

    void Flip()
    {
        if ((move.x < 0 && lookRight) || (move.x > 0 && !lookRight))
        {
            lookRight = move.x >= 0;
            spriteRenderer.flipX = move.x < 0;
            swordSlash.Flip();
        }
    }

    void Dash()
    {
        if (move == Vector2.zero)
        {
            move = new Vector2(lookRight ? 1f : -1f, 0);
        }
        move.Normalize();
        rb.AddForce(move * dashSpeed, ForceMode2D.Impulse);
    }


    private bool IsGrounded()
    {
        // Check if a circle at bottom of the character touch the ground
        Vector2 bottom = (Vector2)transform.position + Vector2.Scale(capsule.offset - new Vector2(0, capsule.size.y / 2f), (Vector2)transform.localScale);
        return Physics2D.OverlapCircle(bottom, 0.5f, groundLayer);
    }

    private void ApplyCurveGravity()
    {
        jumpTime += Time.deltaTime;
        float t = jumpTime / maxJumpTime;
        t = Mathf.Clamp01(t);

        float gravityMultiplier = jumpGravityCurve.Evaluate(t);

        //Debug.Log("gravityMultiplier : " + gravityMultiplier);

        // Apply modified gravity
        rb.velocity += Vector2.up * (Physics2D.gravity.y * (gravityMultiplier - 1f) * Time.deltaTime);
    }


    override public void Hit(int damages)
    {
        base.Hit(damages);
        if (health == 0)
        {
            Die();
        }
    }

}
