using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    //What to do for this code
    //1. Get player color
    //2. Get color from guard, block and spotlight(using tags)
    //3. Check the color of the player vs the color of the 3 gametypes
    //4. Do following things to player if collided
    //disable collider when color code is at a 
    //certain level(ie when player hits button is at a specific code color) 

    public Color playerColor;
    public int OverlapCollider;

    // Start is called before the first frame update
    void Start(){
        playerColor = GetComponent<SpriteRenderer>().color;

    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update(){
        playerColor = GetComponent<SpriteRenderer>().color;
        //Debug.Log(playerColor);

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        GameObject laser = collision.gameObject;
        Collider2D laserCollider = laser.GetComponent<BoxCollider2D>(); 
        Color laserColor = laser.GetComponent<SpriteRenderer>().color;
        if (collision.tag == "Laser" && laserColor.Equals(playerColor) && laserCollider.enabled){
            laserCollider.enabled = !laserCollider.enabled;
        }
        if (collision.tag == "Laser" && !laserColor.Equals(playerColor) && !laserCollider.enabled){
            laserCollider.enabled = !laserCollider.enabled;
        }
    }
}
