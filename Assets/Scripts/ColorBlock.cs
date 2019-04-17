using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    /*
    //set up player color
    public SpriteRenderer playerColor;
    Color checkColor;
    BoxCollider2D boxCollider;
    public Color boxColor;

    // disable collider when color code is at a 
    //certain level(ie when player hits button is at a specific code color)


    void Start()
    {
        // set current player color
        playerColor = GameObject.Find("Fye").GetComponent<ColorShift>().playerColor;
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        boxColor = GetComponent<SpriteRenderer>().color;
        checkColor = playerColor.color; 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && checkColor.Equals(boxColor) && boxCollider.enabled ){
            boxCollider.enabled = !boxCollider.enabled;
        }

        if (collision.tag == "Player" && !checkColor.Equals(boxColor)  && !boxCollider.enabled ){
            boxCollider.enabled = !boxCollider.enabled;
        }
    }
    */

}
