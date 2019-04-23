﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPatrol : MonoBehaviour
{

    public float patrolSpeed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetect;


    private void Update()
    {
        transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, distance );
        if (groundInfo.collider == false ) {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3 (0,-180,0);
                movingRight = false;
            }
            else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
