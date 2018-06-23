using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
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
    }
}
