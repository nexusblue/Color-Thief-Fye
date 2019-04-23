using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.RightShift) ){
            rb.velocity = Vector2.right * dashSpeed * Input.GetAxisRaw("Horizontal"); 
            Debug.Log("Dash button pressed");
        }

        old dash code:
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * dashMultiplier;
        */

    }
}
