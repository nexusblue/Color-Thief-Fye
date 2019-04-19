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
    public Vector3 currCamPos;
    public GameObject cam;

    private void Start(){
        speedLines.SetActive(false);
        StartCoroutine(FreezePlayer());
        currCamPos = GetComponentInChildren<Transform>().localPosition;
        
    }

    // Update is called once per frame
    void Update(){
        BasicMovement();
        DashTemp();
        /*Debug.Log(Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") != 0){

            Vector3 newCamPos = currCamPos + new Vector3(6f * Input.GetAxis("Horizontal") , 0f,0f);
            currCamPos = newCamPos;
            Debug.Log(newCamPos);
            Debug.Log("player is moving");
        }*/
    }

    private void FixedUpdate(){
        controler.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        Attacking();
    }

    private void BasicMovement(){
        //set animation to speed of length of horizonatl press
        if (canMove){
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

    private void Attacking(){
        atkTimer -= Time.deltaTime;
        if ((Input.GetKeyDown(KeyCode.L) || Input.GetButtonDown("Slashing")) && atkTimer <= 0){
            StartCoroutine(Attack());
            SoundManager.playSwordSlash();
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

    //Freeeze player movement when entering new level
    IEnumerator FreezePlayer(){
        yield return new WaitForSeconds(startUpPlayer);
        canMove = true;
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
    IEnumerator TurnOn(){
        yield return new WaitForSeconds(dashLineOnTime);
        speedLines.SetActive(true);
        yield return new WaitForSeconds(dashLineOffTime);
        speedLines.SetActive(false);
    }

}

    /*

    */
