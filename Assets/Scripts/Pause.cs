using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    AudioClip pauseClip;
    public AudioSource pauseSource;
    public GameObject pauseScreen;

    // Update is called once per frame
    void Update(){
        PauseGame();
        QuitGame();
    }

    public void PauseGame(){
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Pause")){
            if (Time.timeScale == 1){
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

    public static void QuitGame(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
