using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Deals with player move values and rigidbodies
    public float speed = 15;
    public float jumpForce = 5;
    private float moveInput;
    private Rigidbody2D rb;

    //change sprite direction
    private bool facingRight = true;

    //Deals with floor jumping
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGrounded;
    private int extraJumps;
    public int extraJumpValue;

    // Use this for initialization
    void Start () {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        Jumping();

    }


    private void Jumping()
    {   //check if player is grounded
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if ((Input.GetKeyDown(KeyCode.Space) && extraJumps > 0))
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps -= 1;
        }
        else if ((Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    // Update is called once per frame
    void FixedUpdate (){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);
        //check for player movement with arrow keys
        PlayerMoveMent();
    }

    //update player movement
    private void PlayerMoveMent(){
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0){
            Flip();
        }
        else if (facingRight == true && moveInput < 0){
            Flip();
        }
    }

    //Filps player sprite
    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }



}
