using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAnimToPlayer : MonoBehaviour
{
    public Image transitionPos;

    // Update is called once per frame
    void Update()
    {
        Vector2 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        //transitionPos.transform.position = namePos;
    }
}
