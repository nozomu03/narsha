using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  최초 작성자: 경준이
 *  목적: 플레이어 캐릭터
 *  최초 작성일: 5/12/2018
 * 최근 수정일: 5/12/2018
*/

public class Player : MonoBehaviour {

	// Use this for initialization
	public float movePower = 1f;
	public float jumpPower = 1f;

	Rigidbody2D rigid;//있어야댐 왜하면 중력적용 땜

	Vector3 movement;//움직이는 벡터값

	bool isJumping = false;//기본 점핑값 거짓
		
	void Start () {//시작시 중력적용
		rigid = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {//점프버튼 실행시 bool점프 true로 활성화
			isJumping = true;
		}
	}

	void FixedUpdate(){//업데이트 보조
		Move();//무브 호출
		Jump();//점프 호출 
		}

	void Move (){
	
		Vector3 moveVelocity = Vector3.zero;

		if (Input.GetAxisRaw ("Horizontal") < 0) {
            moveVelocity = Vector3.left;
        } 

		else if (Input.GetAxisRaw ("Horizontal") > 0) {
			moveVelocity = Vector3.right;

		}
		transform.position += moveVelocity * movePower * Time.deltaTime;
	
	}

	void Jump(){
		if (!isJumping)//지금 점프이면?
			return;
        

		rigid.velocity = Vector2.zero;

		Vector2 jumpVelocity = new Vector2 (0, jumpPower);
		rigid.AddForce (jumpVelocity, ForceMode2D.Impulse);

		isJumping = false;
	}
}
