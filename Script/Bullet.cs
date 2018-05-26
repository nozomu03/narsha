﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private const float moveSpeed = 0.45f;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime;

        transform.Translate(moveX, 0, 0);
    }
}
