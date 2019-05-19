using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectJewel : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable"){
            score += 1;
            Destroy(collision.gameObject);
            Debug.Log(score);
        }
    }
}
