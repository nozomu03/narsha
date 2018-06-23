using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
<<<<<<< HEAD
    //BulletController
    //이지민 최초수정(2018.5.26)
    private const float moveSpeed = 0.45f;
    public GameObject gameObject;
	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        float moveX = moveSpeed * Time.DeltaTime();
        transform.Translate(vector3.right)
=======

    private const float moveSpeed = 0.45f;

	// Use this for initialization
	void Start () {

    }

    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime;
        this.transform.Translate(new Vector3(moveX, 0, 0));
>>>>>>> d8b8e1b54e3a25939dac1a24dfcf9c0df0180292
    }
}
