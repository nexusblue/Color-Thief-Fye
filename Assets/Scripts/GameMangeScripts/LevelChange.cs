using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{

    public int sceneIndex;
    public Animator anim;

    void FadeToLevel(int levelIndex) { 
    
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            Debug.Log("player collided");
            StartCoroutine(NextLevelTransition());
            GameObject.Find("Fye").GetComponent<CharacterController2D>().enabled = false;
        }
    }

    IEnumerator NextLevelTransition() {
        anim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(.40f);
        SceneManager.LoadScene(sceneIndex);

    }
}
