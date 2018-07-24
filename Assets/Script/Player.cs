using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 *  최초 작성자: 한경준
 *  목적: 플레이어 캐릭터 컨트롤러
 *  최초 작성일: 5/12/2018
 * 최근 수정일: 5/12/2018
*/


public class Player : MonoBehaviour {

    // public Transform groundCheck;
    //public LayerMask groundLayers;
    //private float groundCheckRadius = 1.0f;
    // public bool isGrounded = false;//T: 붙음 F: 안붙음
    //bool isJumping = false;//기본 점핑값 거짓



    public TextMesh t_mesh;
    float mapLoadTime=0.0f;
	// Use this for initialization
	public float movePower = 1f;
	public float jumpPower = 1f;

    //새로운 그라운드 체크
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayers;
    public bool isTouchingGround;



    bool groundhit = true;

    bool direction = true;// 기본값 오른쪽이다.

    public float attackpoint = 20f;

    public GameObject Player_Prefab;
    public GameObject Bullet_Prefab;

    public bool canMove = true;
    public bool canJump = true;
   
    float time = 0.0f;
    int bullet = 2;
    bool canShot = true;
    float temp;
    float time2;
    float time3;
    public int canJumpcount=1;
    bool checking=true;

    ToggleControl tg_con;

    public Transform dummy1;

    ShowDialog showdialog;

    public float p_hp = 200f;

    public Image slider;

    public Transform dummy;

    Rigidbody2D rigidBody;//있어야댐 왜하면 중력적용 땜

    Animator anim;

    public bool isSturn = false;

	Vector3 movement;//움직이는 벡터값

    float sturn_count = 0.0f;

    float rollingtime = 0.0f;
		
	/*void Start () {//시작시 중력적용
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}*/

    // Update is called once per frame
    void Start()
    {
        t_mesh.text = "2/2";
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //dummy1.position = gameObject.transform.position;
        tg_con = GetComponent<ToggleControl>();
        anim.SetBool("jumping", false);
        showdialog = gameObject.GetComponent<ShowDialog>();

    }
    void Update() {

        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        dummy1.position = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y + 3, gameObject.transform.position.z);
        // isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);
        //Debug.Log("그라운드췍: "+isTouchingGround);
        // Debug.Log("LIVE!");
        //Debug.Log(p_hp);

        if (anim.GetBool("rolling"))
            rollingtime += Time.deltaTime;
        if (rollingtime >= 1.0)
        {
            anim.SetBool("rolling", false);
            rollingtime = 0.0F;
        }

        if (gameObject.transform.position.y <= -30f)
            p_hp = 0;

        if (isSturn)
        {
            anim.SetBool("Sturn", true);
            Debug.Log("스턴: " + anim.GetBool("Sturn"));


        }

        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.W))
            tg_con.GoNextMap();

        if (p_hp <= 0)
        {
            Debug.Log("DIE!");
            canMove = false;
            Variables.nowScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("You_Dead");           
        }
        if (isTouchingGround == false)
        {

            anim.SetBool("jumping", true);
        }
        else if (isTouchingGround == true)
        {
            anim.SetBool("jumping", false);
        }

        time3 += Time.deltaTime;

        time += Time.deltaTime;
        //Debug.Log(time);

        if (anim.GetBool("Sturn"))
        {
            sturn_count += Time.deltaTime;
        }

        if (sturn_count >=4.0)
        {
            anim.SetBool("Sturn", false);
            isSturn = false;
            sturn_count = 0f;
        }

        if (tg_con.togglebool == true)
            mapLoadTime += Time.deltaTime;        

        time2 += Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isTouchingGround == true && isSturn==false)
        {//점프버튼 실행시 bool점프 true로 활성화
            //Debug.Log("점프 활성화!, "+groundhit);
            //groundhit = false;
            Debug.Log("점프 진입직전");

            checking = false;
            Jump();
            //playSound("WoodenWalk");
            //Debug.Log("또박또박");
            //isJumping = true;
        }
        if (anim.GetBool("Sturn")) {
            Debug.Log("지금은 스턴");
            allParamOff();            
        }
        else
        {
            Move();
            Roll();
            Shooting();
            CheckBullet();
            Reload();
        }
        t_mesh.text = bullet + "/2";
        if(anim.GetBool("shooting"))
            temp += Time.deltaTime;
        //Attacked(10f);
        //  Debug.Log(temp);
        //Debug.Log(checking + ":"+groundhit);
	}

    void allParamOff()
    {
        anim.SetBool("moving", false);
        anim.SetBool("reloading", false);
        anim.SetBool("jumping", false);
    }
    
    public void Attacked(float damage)
    {
        if (!anim.GetBool("rolling"))
        {
            p_hp -= damage;
            slider.fillAmount = p_hp / 200f;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Finish"))
        {
            Debug.Log("통과");
            tg_con.togglebool = true;
            
        }
    }
    void CheckBullet()
    {
        if (bullet <= 0)
        {
            canShot = false;
        }
    }

    void Shooting()
    {
        if (canShot==true && anim.GetBool("jumping")==false && anim.GetBool("rolling")==false && anim.GetBool("reloading")==false)
        {        
            if (!anim.GetBool("shooting"))
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    playSound("GunFire");
                    bullet -= 1;
                    anim.SetBool("shooting", true);
                    temp = 0.0f;
                    Instantiate(Bullet_Prefab, dummy.position, dummy.rotation);                 
                }
            }       
        }
        if (temp >= 1.5f)
        {
            anim.SetBool("shooting", false);
        }

    }

    void Reload()
    {
        if (bullet < 2)
        {
            if (Input.GetKeyDown(KeyCode.X) )
            {
                //  canMove = false;//장전중 움직임 정지
                
                time2 = 0.0f;
                anim.SetBool("moving", false);
                anim.SetBool("reloading", true);

            }
            if (anim.GetBool("reloading") && time2>=2.24f)
            {
                playSound("ReL");//리로드 사운드
                anim.SetBool("reloading", false);
                bullet = 2;
                canShot = true;
             //   canMove = true;
            }
        }
    }

    void Move(){
        if (canMove == true)
        {
            //Debug.Log("能");
            Vector3 moveVelocity = Vector3.zero;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("moving", true);
                moveVelocity = Vector3.right;
                gameObject.transform.Translate(Vector2.right * movePower);
                direction = true;
                playSound("WoodenWalk");
                //Debug.Log("사운드 재생");

                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
                dummy.localRotation = Quaternion.Euler(0, 0, 0);
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("moving", true);
                moveVelocity = Vector3.left;
                gameObject.transform.Translate(Vector2.left * movePower);
                direction = false;
                playSound("WoodenWalk");

                //Debug.Log("사운드 재생");

                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
                dummy.localRotation = Quaternion.Euler(0, 180, 0); 
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                muteSound("WoodenWalk");
                //Debug.Log("오른쪽 사운드 중지");
                anim.SetBool("moving", false);
                
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                muteSound("WoodenWalk");
                Debug.Log("왼쪽 사운드 중지");
                anim.SetBool("moving", false);       
            }
        }    
    }

    void Roll()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("rolling", true);
        }
    }

    void Jump()
    {       
        Debug.Log("부양");
        rigidBody.velocity = new Vector2(rigidBody.velocity.y, 0);
        rigidBody.AddForce(Vector2.up*(jumpPower*2),ForceMode2D.Impulse);
        Debug.Log("점프anime: true");
        time = 0f;
        checking = true;
    }

    void playSound(string snd)
    {
         GameObject.Find(snd).GetComponent<AudioSource>().Play();
    }
    void muteSound(string snd)
    {
     //   GameObject.Find(snd).GetComponent<AudioSource>().Stop();
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
