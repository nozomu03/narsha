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
    public bool isGrounded = false;//T: 붙음 F: 안붙음
    bool groundhit = false;

    public Transform groundCheck;
    public LayerMask groundLayers;

	Rigidbody2D rigidBody;//있어야댐 왜하면 중력적용 땜

	Vector3 movement;//움직이는 벡터값

	//bool isJumping = false;//기본 점핑값 거짓
		
	/*void Start () {//시작시 중력적용
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}*/

    // Update is called once per frame
    void start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update () {
        if (Input.GetButtonDown("Jump")){//점프버튼 실행시 bool점프 true로 활성화
            Debug.Log("점프 활성화!");
            Jump();
            //isJumping = true;
        }
        
            Move();
        
	}

	/*void FixedUpdate(){//업데이트 보조
		//Move();//무브 호출
		Jump();//점프 호출 
		}*/

    void Move(){
	
		Vector3 moveVelocity = Vector3.zero;

		if (Input.GetAxisRaw ("Horizontal") < 0) {
            moveVelocity = Vector3.left;
        } 

		else if (Input.GetAxisRaw ("Horizontal") > 0) {
			moveVelocity = Vector3.right;

		}
		transform.position += moveVelocity * movePower * Time.deltaTime;
	
	}

    void Jump()
    {
        if (!groundhit)
        {
            //gameObject.transform.Translate(Vector2.up * jumpPower);


            //rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            //rigidBody.AddForce(new Vector2(0, jumpPower));
            Debug.Log("부양");
            rigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            groundhit = true;
        }

       /* if (!isJumping)//지금 점프이면?
            return;
        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;*/
    }

    public LayerMask groundLayer;

    /*void OnCollisionStay2D(Collision2D other){
        if (other.gameObject.tag=="ground")
        {
            Debug.Log("땅 밟음");
            groundhit = false;
        }
    }*/
}
