using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    public LayerMask groundLayer;

    PlayerControls controls;
    private Rigidbody2D rb;
    CapsuleCollider2D capsule;

    private Vector2 move;
    public bool doubleJump;

    private void Awake()
    {
        capsule = GetComponent<CapsuleCollider2D>();
        controls = new PlayerControls();
        controls.Gameplay.Jump.performed += ctx => Jump();
        //controls.Gameplay.Move.performed += ctx => Move();
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;


        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }



    void Jump()
    {
        if ( IsGrounded() || doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = ! doubleJump;
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(move.x * moveSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        // Check if a circle at bottom of the character touch the ground
        Vector2 bottom = (Vector2)transform.position + Vector2.Scale(capsule.offset - new Vector2(0, capsule.size.y / 2f), (Vector2)transform.localScale);
        return Physics2D.OverlapCircle(bottom, 0.5f, groundLayer);
    }






    /*private void OnDrawGizmos()
    {
        if (capsule == null)
            capsule = GetComponent<CapsuleCollider2D>();

        Vector2 bottom = (Vector2)transform.position + Vector2.Scale(capsule.offset - new Vector2(0, capsule.size.y / 2f), (Vector2)transform.localScale);
        Gizmos.color = isGrounded ? Color.green : Color.red; ;
        Gizmos.DrawSphere(bottom, 0.1f);
    }*/




}
