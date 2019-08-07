using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour{

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

}

