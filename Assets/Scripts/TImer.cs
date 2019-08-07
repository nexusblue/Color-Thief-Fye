using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TImer : MonoBehaviour
{
    public float startTime;
    public TextMeshProUGUI timerText;

    void Awake(){
        //DontDestroyOnLoad(GameObject.Find("Canvas"));
        DontDestroyOnLoad(this);
    }

    private void Start(){
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update(){
        //start the time and get the timer setup in min:sec
        float currentTime = Time.time - startTime;
        string minutes = ((int)(currentTime) / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        //string millSecs = ((currentTime * 100f) %100).ToString("F0");
        timerText.text = "Timer: " + minutes + ":" + seconds;
    }
}
