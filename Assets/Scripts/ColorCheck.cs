using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ColorCheck : MonoBehaviour{

    //What to do for this code
    //1. Get player color
    //2. Get color from guard, block and spotlight(using tags)
    //3. Check the color of the player vs the color of the 3 gametypes
    //4. Do following things to player if collided
    //disable collider when color code is at a 
    //certain level(ie when player hits button is at a specific code color)
    //public int OverlapCollider;
    //check for layer(make a layer for each color) configure collision matrix 
    //project settings-> collision matrix 
    //change layer when chaning color 

    //Create health and stealth values 
    float health = 100;
    float stealth;
    float stealthStart = 100;
    public float stealthRate = 1f;
    public float healthRate = 1f;
    //Track player color and stealth text
    Color playerColor;
    public TextMeshProUGUI stealthLvl;


    void Start(){
        //set stealth value and player color to sprite render
        stealth = stealthStart;
        playerColor = GetComponent<SpriteRenderer>().color;
    }


    void Update(){
        //update stealth text and player color 
        playerColor = GetComponent<SpriteRenderer>().color;
        stealthLvl.text = "Detection Level:" + Mathf.Round(stealth).ToString();
    }

    private void OnTriggerStay2D(Collider2D collision){
        //check for lasers and disable collider
        //if player color == laser color and vice versa
        GameObject laser = collision.gameObject;
        Collider2D laserCollider = laser.GetComponent<BoxCollider2D>();
        Color laserColor = laser.GetComponent<SpriteRenderer>().color;
        if (collision.tag == "Laser" && laserColor.Equals(playerColor) && laserCollider.enabled){
            laserCollider.enabled = !laserCollider.enabled;
        }
        if (collision.tag == "Laser" && !laserColor.Equals(playerColor) && !laserCollider.enabled){
            laserCollider.enabled = !laserCollider.enabled;
        }
        //check for spotlight and subtract detection value
        //if player color != laser color
        GameObject spotlight = collision.gameObject;
        Color spotlightColor = spotlight.GetComponent<SpriteRenderer>().color;
        if (collision.tag == "Spotlight" && !spotlightColor.Equals(playerColor)){
            stealth = (stealth - (stealthRate * Time.deltaTime));
        }
        //check for and destroy collectable 
        if (collision.tag == "Collectable"){
            Destroy(collision.gameObject);
        }
    }

}
