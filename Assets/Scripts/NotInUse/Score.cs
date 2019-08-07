using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour{
    // create the jeweltypes and update the
    // score values when collected
    public enum Jewels { GREENSTONE, REDSTONE, BLUESTONE };
    //public Text score;
    public TextMeshProUGUI score;
    public float scoreAddValue = 0;
    public bool grabJewelOnce ;

    public void Start(){
        score.text = "$: " + scoreAddValue.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Collectable" && !grabJewelOnce){
            grabJewelOnce = true;
            scoreAddValue += 10;
            Destroy(collision.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        grabJewelOnce = false;
    }

    private void Update(){
        score.text = "$: " + scoreAddValue.ToString();
    }

}
//What to do for this code
//1. Get player color
//2. Get color from guard, block and spotlight(using tags)
//3. Check the color of the player vs the color of the 3 gametypes
//4. Do following things to player if collided
//disable collider when color code is at a 
//certain level(ie when player hits button is at a specific code color)
//check for layer(make a layer for each color) configure collision matrix 
//project settings-> collision matrix 
//change layer when chaning color 
/*

        // grab the jewel types from score.cs script
    // and refrence the the scoreValue
    public Score.Jewels jewelTypes;
    bool sentinel = false;
    public Score myScore;

    private void Update(){
        //Debug.Log(myScore.scoreValue);
    }
    // if the gameobject(in this case a jewel) collides 
    // with the player destory the object and update score
    // according to jewel type
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            switch (jewelTypes){
                case Score.Jewels.GREENSTONE:
                    //myScore.scoreValue += 1;
                    //Debug.Log("green");
                    break;
                case Score.Jewels.REDSTONE:
                    //myScore.scoreValue += 1;
                    //Debug.Log("red");
                    break;
                case Score.Jewels.BLUESTONE:
                    //myScore.scoreValue += 1;
                    //Debug.Log("blue");
                    break;
            }
            SoundManager.playCollectSound();
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    */
