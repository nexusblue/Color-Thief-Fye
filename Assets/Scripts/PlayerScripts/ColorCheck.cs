using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ColorCheck : MonoBehaviour {

    //Create health and stealth values 
    float health = 100;
    float stealth;
    public Slider stealthSlider;

    public float healthRate = 1f;
    //Track player color and stealth text
    Color playerColor;
    float stealthStart = 100;
    public float stealthRate = 1f;
    public TextMeshProUGUI stealthLvl;
    public int currentLvl ;

    void Start() {
        //set stealth value and player color to sprite render
        stealth = stealthStart;
        playerColor = GetComponent<SpriteRenderer>().color;
        stealthSlider.value = 100;
    }


    void Update() {
        //update stealth levels and player color 
        playerColor = GetComponent<SpriteRenderer>().color;
        stealthLvl.text = "Detection Level:" + Mathf.Round(stealth).ToString();
        //if stealth is below zero restart the level
        if (stealth <= 0) {
            SceneManager.LoadScene(currentLvl);
        }
        stealthSlider.value = stealth;

    }

    private void OnTriggerStay2D(Collider2D collision){
        CheckForLaser(collision);
        CheckForSpotLight(collision);
        CheckForEnemy(collision);
    }

    private void CheckForLaser(Collider2D collision){
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
    }

    private void CheckForSpotLight(Collider2D collision){
        //check for spotlight and subtract detection value
        //if player color != laser color
        GameObject spotlight = collision.gameObject;
        Color spotlightColor = spotlight.GetComponent<SpriteRenderer>().color;
        if (collision.tag == "Spotlight" && !spotlightColor.Equals(playerColor)){
            stealth = (stealth - (stealthRate * Time.deltaTime));
        }
    }

    private void CheckForEnemy(Collider2D collision){
        //check for enemy and kill player
        //if player color != patrol color
        GameObject patrolUnit = collision.gameObject;
        Color patrolUnitColor = patrolUnit.GetComponent<SpriteRenderer>().color;
        if (collision.tag == "Enemy" && !patrolUnitColor.Equals(playerColor)){
            Debug.Log("Collided with and color is not the same");
            //stealth = (stealth - (stealthRate * Time.deltaTime));
            SceneManager.LoadScene(currentLvl);
        }
        if (collision.tag == "Enemy" && patrolUnitColor.Equals(playerColor)){
            Debug.Log("Collided and color is the same");

        }
    }

}
