using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour{
    // create the jeweltypes and update the
    // score values when collected
    public enum Jewels { GREENSTONE, REDSTONE, BLUESTONE };
    public TextMeshProUGUI score;
    public float scoreValue;

    private void FixedUpdate(){
        score.text = "Score:" + scoreValue.ToString();
    }
}
