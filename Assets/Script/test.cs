using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    Animator tanim;
    float time = 0.0f;
	// Use this for initialization
	void Start () {
        tanim = GetComponent<Animator>();
        CheckShot();
	}
	
	// Update is called once per frame
	void Update () {
        //CheckShot();
        if(tanim.GetBool("shot")==true)
            time += Time.deltaTime;
	}

    void CheckShot()
    { 
        tanim.SetBool("shot", true);
        if (time >= 1.0f)
        {
            tanim.SetBool("shot", false);
            time = 0.0f;            
        }
    }
}
