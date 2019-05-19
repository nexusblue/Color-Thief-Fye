using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Instructions;
    // Update is called once per frame
    void Update(){

    }

    public void ShowInstructions() {
        if (Instructions.activeSelf == false ){
            Instructions.SetActive(true);
        }

    }

    public void ExitInstructions() {
        if (Instructions.activeSelf == true){
            Instructions.SetActive(false);
        }
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Debug.Log("quit game");
        Application.Quit();
    }
}
