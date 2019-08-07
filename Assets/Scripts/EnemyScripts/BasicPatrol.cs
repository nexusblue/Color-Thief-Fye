using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPatrol : MonoBehaviour{

    public float patrolSpeed;
    public float distance;

    public Transform groundDetect;

    public Transform[] patrolSpots;
    private int randomSpot;
    private float waitTime;
    public float startTime;

    private void Start(){
        waitTime = startTime;
        //randomSpot = Random.Range(0,patrolSpots.Length);
        randomSpot = 0;
    }

    private void Update(){

        transform.position = Vector2.MoveTowards(transform.position, patrolSpots[randomSpot].position, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position,patrolSpots[0].position) < 0.2f ) {
            if (waitTime <= 0){
                randomSpot = 1;
                waitTime = startTime;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else{
                waitTime -=Time.deltaTime ;  
            }
        }
        if (Vector2.Distance(transform.position, patrolSpots[1].position) < 0.2f){
            if (waitTime <= 0){
                randomSpot = 0;
                waitTime = startTime;
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else{
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "PlayerAtk"){
            //make player pass through enemy with layers
            Destroy(gameObject);
        }
    }
}
