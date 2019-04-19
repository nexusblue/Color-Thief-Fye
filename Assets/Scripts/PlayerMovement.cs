using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // when adding in slide/ get rid of crouch 
    //but disable box collider for slide
    public CharacterController2D controler;
    public Animator anim;
    public GameObject speedLines;
    float horizontalMove = 0;

    public float runSpeed = 100.0f;
    public float dashMultiplier = 30.0f;
    public float dashCoolDown = 1f;
    public float atkCoolDown = 1f;
    public float atkbtwTime = 0.005f;

    private float dashTimer;
    private float atkTimer;
    private float dashLineOnTime = 0.066f;
    private float dashLineOffTime = 0.066f;
    bool jump;
    bool crouch;
    bool canMove = false;
    public float startUpPlayer = 0.15f;

    private void Start(){
        speedLines.SetActive(false);
        StartCoroutine(FreezePlayer());
    }

    IEnumerator FreezePlayer() {
        yield return new WaitForSeconds(startUpPlayer);
        canMove = true;
    }

    // Update is called once per frame
    void Update(){
        BasicMovement();
        DashTemp();
    }

    private void FixedUpdate(){
        controler.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        Attacking();

    }

    private void BasicMovement(){
        //set animation to speed of length of horizonatl press
        if (canMove)
        {
            anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
            //check if jump or crouch button were pressed
            if (Input.GetButtonDown("Jump") ){
                jump = true;
                SoundManager.playJumpYell();
                anim.SetBool("isJumping", true);
            }
            if (Input.GetButtonDown("Crouch") )  {
                crouch = true;
            }
            if (Input.GetButtonUp("Crouch")){
                crouch = false;
            }
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        }
    }
    
    private void DashTemp(){
        //set dash timer to reset after key press
        dashTimer -= Time.deltaTime;
        //check if able to dash/ play dash sound and reset time until next dash 
        if ((Input.GetKeyDown(KeyCode.RightShift) || Input.GetButtonDown("Dash")) && Input.GetAxisRaw("Horizontal")!= 0 && dashTimer <= 0  )  {
            dashTimer = dashCoolDown;
            StartCoroutine(TurnOn());
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * dashMultiplier;
            SoundManager.playDash();
        }

    }

    //Check for landing or crouching 
    //and change animations accordingly
    public void onLanding()
    {
        anim.SetBool("isJumping", false);
    }
    public void onCrouching(bool isCrouching)
    {
        anim.SetBool("isCrouching", isCrouching);
    }

    private void Attacking(){
        atkTimer -= Time.deltaTime;
        if ((Input.GetKeyDown(KeyCode.L) || Input.GetButtonDown("Slashing")) && atkTimer <= 0){
            StartCoroutine(Attack());
            SoundManager.playSwordSlash();
        }

    }

    IEnumerator Attack(){
        yield return new WaitForSeconds(atkbtwTime);
        anim.SetBool("Attacking", true);
        atkTimer = atkbtwTime; 
        yield return new WaitForSeconds(atkbtwTime);
        anim.SetBool("Attacking", false);
    }

    // cool down time to next dash time
    IEnumerator DashTimer(){
        yield return new WaitForSeconds(dashCoolDown);
    }

    // show speed lines when dashing and turn off afterward
    IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(dashLineOnTime);
        speedLines.SetActive(true);
        yield return new WaitForSeconds(dashLineOffTime);
        speedLines.SetActive(false);
    }


}

    /*
    public GameObject camera;
    Transform camTransform;
    public float smoothCamSpeed = 0.125f;
    public Vector3 offset;
    Transform playerPos;

    camTransform = camera.GetComponent<Transform>();

    Vector3 desiredPos = playerPos.position + offset;
    Vector3 smoothedPos = Vector3.Lerp (camTransform.position,desiredPos,smoothCamSpeed);
    */
