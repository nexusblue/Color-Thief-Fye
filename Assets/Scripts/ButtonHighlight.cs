using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonHighlight : MonoBehaviour
{
    public Image ButtonHighlighted;

    public void OnMouseEnter(){
        ButtonHighlighted.GetComponent<Image>().color = new Color(0.70f, 0.70f, 0.70f, 1);
        //Debug.Log("Mouse Entered");
    }
    public void OnMouseExit(){
        ButtonHighlighted.GetComponent<Image>().color = Color.white;
    }
}
