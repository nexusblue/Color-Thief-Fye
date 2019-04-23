using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{
    public int scoreValue;
    public TextMeshProUGUI score;

    public enum Jewels { GREENSTONE, REDSTONE, BLUESTONE };
    public Jewels jewelType;

    void Update(){
        Debug.Log(scoreValue);

    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" ){
            switch (jewelType){
                case Jewels.GREENSTONE:
                    scoreValue += 50;
                    score.text = "Score: " + scoreValue.ToString();
                    break;
                case Jewels.REDSTONE:
                    scoreValue += 50;
                    score.text = "Score: " + scoreValue.ToString();
                    break;
                case Jewels.BLUESTONE:
                    scoreValue += 50;
                    score.text = "Score: " + scoreValue.ToString();
                    break;
            }
            score.text = "Score: " + scoreValue.ToString();
            SoundManager.playCollectSound();
            Destroy(gameObject);
        }

    }
}
