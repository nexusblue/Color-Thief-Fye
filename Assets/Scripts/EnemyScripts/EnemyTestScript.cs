using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestScript : MonoBehaviour
{

    public float health = 100.0f;
    public float damage = 25.0f;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAtk")
        {
            health -= damage;
            Debug.Log("Enemy hit. Health is " + health);
        }
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
