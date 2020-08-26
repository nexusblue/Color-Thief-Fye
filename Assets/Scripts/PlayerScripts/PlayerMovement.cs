using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // when adding in slide/ get rid of crouch 
    // but disable box collider for slide
    public CharacterController2D controler;
    public Animator anim;
    public GameObject speedLines;
    float horizontalMove = 0;

    public float runSpeed = 100.0f;
    public float dashMultiplier = 30.0f;
    public float dashCoolDown = 1f;
    public float atkCoolDown = 1f;
    public float atkbtwTime = 0.005f;
    public float startUpPlayer = 0.15f;
    public GameObject AttackCollider;
    //cooldown times btw timer and atk windows
    private float dashTimer;
    private float atkTimer;
    private float dashLineOnTime = 0.066f;
    private float dashLineOffTime = 0.066f;
    // check if jumping or crouching
    // make player freeze with canMove
    // inorder to show effect
    bool jump;
    bool crouch;
    bool canMove = false;
    Rigidbody2D rb;

    private void Start(){
        // freeze player for animation
        //start with speedlines off
        StartCoroutine(FreezePlayer());
        speedLines.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        if (canMove){
            BasicMovement();
        }
    }

    private void FixedUpdate(){
        controler.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        Attacking();
        DashTemp();
    }

    private void BasicMovement(){
        //set animation to speed of length of horizonatl press
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //check if jump or crouch button were pressed
        if (Input.GetButtonDown("Jump") ) {
            jump = true;
            SoundManager.playJumpYell();
            anim.SetBool("isJumping", true);
        }
        /*
        if (Input.GetButtonDown("Crouch")){
            crouch = true;
        }
        if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }*/
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }
    
    private void DashTemp(){
        //set dash timer to reset after key press
        dashTimer -= Time.deltaTime;
        //check if able to dash/ play dash sound and reset time until next dash 
        if (( Input.GetKeyDown(KeyCode.J) || Input.GetButtonDown("Dash")) && Input.GetAxisRaw("Horizontal")!= 0 && dashTimer <= 0  )  {
            dashTimer = dashCoolDown;
            StartCoroutine(TurnOnDash());
            rb.velocity = Vector2.right * dashMultiplier * Input.GetAxisRaw("Horizontal");
            SoundManager.playDash();
        }
    }

    private void Attacking(){
        atkTimer -= Time.deltaTime;
        if ((Input.GetKeyDown(KeyCode.L) || Input.GetButtonDown("Slashing")) && atkTimer <= 0){
            StartCoroutine(Attack());
        }

    }

    //Check for landing or crouching 
    //and change animations accordingly
    public void onLanding(){
        anim.SetBool("isJumping", false);
    }

    //Freeeze player movement when entering new level
    IEnumerator FreezePlayer(){
        yield return new WaitForSeconds(startUpPlayer);
        canMove = true;
    }
    // make a delay when player is attacking
    IEnumerator Attack(){
        yield return new WaitForSeconds(atkbtwTime);
        AttackCollider.SetActive(true);
        anim.SetBool("Attacking", true);
        SoundManager.playSwordSlash();
        atkTimer = atkbtwTime; 

        yield return new WaitForSeconds(atkbtwTime);
        anim.SetBool("Attacking", false);
        AttackCollider.SetActive(false);

    }

    // cool down time to next dash time
    IEnumerator DashTimer(){
        yield return new WaitForSeconds(dashCoolDown);
    }

    // show speed lines when dashing and turn off afterward
    IEnumerator TurnOnDash(){
        yield return new WaitForSeconds(dashLineOnTime);
        speedLines.SetActive(true);
        yield return new WaitForSeconds(dashLineOffTime);
        speedLines.SetActive(false);
    }
    /*
    public void onCrouching(bool isCrouching){
        anim.SetBool("isCrouching", isCrouching);
    }*/

}

