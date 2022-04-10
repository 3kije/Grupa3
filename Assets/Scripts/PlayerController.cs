using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;
    bool facingRight = true;

    Rigidbody rb2d;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.5f;
    public LayerMask whatIsGround;
    public float jumpForce = 10f;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
  
  

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        animator.SetFloat("Speed", Mathf.Abs(move));
    }



    void Update()
    {
       
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {

            //rb2d.AddForce(new Vector2(0, jumpForce));
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
        }

        if (GetComponent<Rigidbody2D>().velocity.y < 0 && !grounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        else/* if (rb.velocity.y >= 0)*/
        {
            animator.SetBool("isFalling", false);
            //animator.SetBool("IsJumping", false);


        }
    }

       void Flip()

        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    
}