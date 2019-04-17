using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    AudioClip pauseClip;
    public AudioSource pauseSource;
    public GameObject pauseScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) { 
            if(Time.timeScale == 1) {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
                pauseSource.Play();

            }
            else{
                Time.timeScale = 1;
                pauseSource.Play();
                pauseScreen.SetActive(false);
            }

        }
    }
}
