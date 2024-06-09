using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;
    [SerializeField] Transform groundcheckCollider;
    [SerializeField] LayerMask groundLayer;

    public int nyawa;
    Vector2 play;
    public bool play_again;

    const float groundCheckRadius = 0.2f;
    [SerializeField] float speed = 1;
    [SerializeField] float jumpPower = 200;

    float horizontalValue;

    [SerializeField] bool isGrounded;
    bool facingRight = true;
    bool jump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void playagain()
    {
        if (play_again == true)
        {
            nyawa = 3;
            transform.position = play;
            play_again = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jumping", true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
            animator.SetFloat("Blend_Jump", rb.velocity.y);
        }

        if (nyawa < 0)
        {
            playagain();
        }
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, jump);
    }

    //GroundCheck
    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders =
        Physics2D.OverlapCircleAll(groundcheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
            isGrounded = true;
        animator.SetBool("Jumping", !isGrounded);
    }

    void Move(float dir, bool jumpflag)
    {
        if (isGrounded && jumpflag)
        {
            isGrounded = false;
            jumpflag = false;
            rb.AddForce(new Vector2(0f, jumpPower));
        }
        #region gerak kanan kiri
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;
        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        #endregion
        animator.SetFloat("Blend", Mathf.Abs(rb.velocity.x));
    }
}