using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(new Vector2(player.transform.position.x - gameObject.transform.position.x, (player.transform.position.y - gameObject.transform.position.y+4)));
        //Debug.Log(player.transform.position.y - gameObject.transform.position.y);
        //Debug.Log(player.transform.position.x + ":" + gameObject.transform.position.x);
	}
}
