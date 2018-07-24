using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    AudioSource audioData;
        

    void Start(){
        audioData = GetComponent<AudioSource>();      
    }

	    public void buttonPlay(){

            StartCoroutine(SoundAndScene("play"));
        }
	    public void buttonBack(){

            StartCoroutine(SoundAndScene("main"));
        }
	    public void buttonNewGame(){

            StartCoroutine(SoundAndScene("1"));
        }
	    public void buttonCredit(){

            StartCoroutine(SoundAndScene("credit"));
        }

	    public void appQuit(){
		    Application.Quit ();
	    }
        IEnumerator SoundAndScene(string scene){
            audioData.Play();
            yield return new WaitForSeconds(1.0f);
            if (scene == "1")
              Destroy(GameObject.Find("Music"));
            SceneManager.LoadScene(scene);
        }
}
