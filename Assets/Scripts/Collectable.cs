using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{
    public TextMeshProUGUI score;
    public float scoreValue;

    public enum Jewels { GREENSTONE, REDSTONE, BLUESTONE };
    public Jewels jewelType;

    void Update(){
        score.text = "Score: " + scoreValue.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" )
        {
            switch (jewelType){
                case Jewels.GREENSTONE:
                    scoreValue = 25;
                    break;
                case Jewels.REDSTONE:
                    scoreValue = 50;
                    break;
                case Jewels.BLUESTONE:
                    scoreValue = 100;
                    break;
            }
            scoreValue += scoreValue; 
            SoundManager.playCollectSound();
            //Destroy(gameObject);
        }
    }

}
