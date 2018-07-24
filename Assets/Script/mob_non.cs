using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour {

    // Use this for initialization
    public float hp = 40f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hp == 0)
            Destroy(gameObject);
    }
}
