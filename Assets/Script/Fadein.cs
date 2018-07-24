using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadein : MonoBehaviour {
	public UnityEngine.UI.Image fade;
	float fades = 1.0f;
	float time = 0;
	//bool fadeinout = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (fadeinout)
		//	fadeOut ();
		//if (!fadeinout)
			fadeIn ();
		
	}
	void fadeIn(){
		time += Time.deltaTime;
		if (fades > 0.0f && time >= 0.1f) {
			fades -= 0.1f;
			fade.color = new Color (0, 0, 0, fades);
			time = 0;
		} else if (fades <= 0.0f) {
			fade.gameObject.SetActive (false);
			//return;
		}
	}
	/*
	void fadeOut(){
		time += Time.deltaTime;
		if (fades < 1.0f && time >= 0.1f) {
			fades += 0.1f;
			fade.color = new Color (0, 0, 0, fades);
			time = 0;
		}
		else if(fades >= 1.0f)
			fadeinout = !fadeinout;
		}
		*/
}
