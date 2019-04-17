using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthAndStealth : MonoBehaviour
{
    public float health = 100;
    public float stealth;
    public float stealthStart = 1000;
    public float stealthRate = 1f;
    public float stealthRate2 = 1f;
    public float healthRate = 1f;
    public TextMeshProUGUI stealthLvl;

    // Start is called before the first frame update
    void Start(){
        stealth = stealthStart;
    }

    // Update is called once per frame
    void Update(){
        stealthLvl.text = "Detection Level:" + Mathf.Round(stealth).ToString();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ""){
            stealth = (stealth - (stealthRate * Time.deltaTime)) ;
        }
        if (collision.tag == "")
        {
            stealth = (stealth - (stealthRate2 * Time.deltaTime));
        }
        if (collision.tag == "Enemy")
        {
            stealth = 0;
        }
        if (stealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Spike"){
            health -= healthRate;
            Debug.Log(health);
        }
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
