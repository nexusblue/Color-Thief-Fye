using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShift : MonoBehaviour
{
    // get the players sprite
    public SpriteRenderer playerColor;
    public Color blue = new Color( 102,102,255) ;
    public Color red = new Color(252, 102, 102);
    public Color yellow = new Color(255, 255, 102);
    //public Color playerColorNew ;
    //public Color green = new Color(102, 255, 102); 

    TrailRenderer trailColor;
    public int colorCode;

    // Start is called before the first frame update
    void Start(){
        //playerColorNew = Color.white;
        colorCode = 0;
        playerColor.color = Color.white;
        trailColor = GetComponent<TrailRenderer>() ;
        trailColor.material.color = Color.white; 
    }

    private void Update(){
        ColorShiftFoward();
    }

    private void ColorShiftFoward()
    {
        // switch case to check to for color code and which to switch to
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("ColorShiftButton"))){

            switch (colorCode){
                case 0:
                    playerColor.color = red;
                    trailColor.material.color = red;
                    colorCode = 1;
                    break;
                case 1:
                    playerColor.color = red;
                    trailColor.material.color = red;
                    colorCode = 2;
                    break;
                case 2:
                    playerColor.color = blue;
                    trailColor.material.color = blue;
                    colorCode = 3;
                    break;
                case 3:
                    playerColor.color = yellow;
                    trailColor.material.color = yellow;
                    colorCode = 1;
                    break;
            }
            SoundManager.playColorShift();

        }
    }

}


/*
case 3:
playerColor.color = green;
trailColor.material.color = green;
colorCode = 4;
break;*/
