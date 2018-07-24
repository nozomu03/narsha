using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

    public TextMesh txt;
    float time = 0.0f;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        text();
    }
    
    void text()
    {
        if (time >= 3.0f)
        {
            txt.text = "목표 갱신: 이 곳에서 탈출하십시오.";
        }
    }
}
