using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // 캐릭터 스탯
    CapsuleCollider2D capcol; //공격범위
    int p_damage = 0; //공격력
    bool temp = false;
    //장탄수
    int weapon_1 = 4;
    int weapon_2 = 1;
    public float Speed = 7.0f;
    public float jumpForce = 300.0f;

    bool temp2=false;

    float time2 = 0.0f;

    public bool isGrounded = false;//지금 땅에있음?
    public bool isJumping = false;//지금 점프중임?
    public LayerMask groundLayers;

    float time = 0f;
    public Transform groundCheck;
    public int RollPower = 1;//구르는 힘
    public int health = 100;//체력
    public int stemina = 100;//스테미나
    public float grande_throw_pow = 0.5f;//던지는 힘
    public int countspecial = 0;
    //public bool canshoot = true;
    public GameObject bulletprefab1;//1번무기 스프라이트
    public GameObject bulletprefab2;//2번무기 스프라이트
    public GameObject bulletprefab3;//3번무기 스프라이드 

    public GameObject laserPrefab; //발사할 레이저를 저장합니다.
    public bool canShoot = true; //레이저를 쏠 수 있는 상태인지 검사합니다.
    const float shootDelay = 0.5f; //레이저를 쏘는 주기를 정해줍니다.
    float shootTimer = 0; //시간을 잴 타이머를 만들어줍니다.

    bool first_canShot = true;
    bool second_canShot = true;

    public int Change = 1;//웨폰 스위칭 
    public int Specialmeter = 0;//특수무기 게이지
    private float groundCheckRadius = 1.2f;
    
    void timer()
    {
        if (time >= 2.0)
        {
            Debug.Log("장전 완료.");
            weapon_1 = 4;
            temp = false;
            time = 0;
        }
        else
        {
            if(temp==true)
                Debug.Log("장전중");
        }
    }
    
    void timer2()
    {
        if (time2 >= 2.8)
        {
            Debug.Log("장전 완료.");
            weapon_2 = 1;
            temp2 = false;
            time2 = 0;
        }
        else
        {
            if (temp2 == true)
                Debug.Log("장전중");
        }
    }

    Rigidbody2D rb2D;


    /*
     최초작성일: 05/15/2018
     최초작성자: 경준이
     목적: 캐릭터 컨트롤러
     */

    //플레이어 공격력, 공격범위
    public void Playerstatus()
    {
        if (Change == 1)
        {
            capcol.size = new Vector2(120f, 6.6f);
            Debug.Log("사이즈: " + capcol.size);
            p_damage = 50;
        }
        else if (Change == 2)
        {
            capcol.size = new Vector2(75f, 6.6f);
            Debug.Log("사이즈: " + capcol.size);
            p_damage = 70;
        }

        else if (Change == 3)
        {          
            capcol.size = new Vector2(30f, 6.6f);
            Debug.Log("사이즈: " + capcol.size);
            p_damage = 30;
        }

    }
    
    
    void Start()
    {
       
        Debug.Log("정상적 실행 완료. 중력적용 완료");
        rb2D = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {
        //Bulletcheck();
        if(temp==true)
            time += Time.deltaTime;

        if (temp2 == true)
            time2 += Time.deltaTime;

        timer();
        timer2();
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * Speed, rb2D.velocity.y);
        rb2D.velocity = moveDir;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);//User 중심점이 ground태그 오브젝트와 충돌시 true값


        if (Input.GetKeyDown(KeyCode.C))
        {
            Dodge();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("스페이스 눌름");
            if (isGrounded == true)
            {
                Debug.Log("점프파워 가동");
                rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
                rb2D.AddForce(new Vector2(0, jumpForce));
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))//펌프액션
        {
            Debug.Log("무기 1번 교체됨!");
            Change = 1;
            Playerstatus();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))//소드오프
        {
            Debug.Log("무기 2번 교체됨");
            Change = 2;

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("무기 3번 교체됨");
            Change = 3;

        }

        else if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("공격명령!");
            Attack();
          //  ShootingTest();
        }

       else if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("스페셜어택 명령!");
        }


    }
    void Dodge()//회피기동
    {
        Debug.Log("회피기동 함수 도착");
        if (isGrounded == true)//땅에 있을때만 회피작동
        {
            
            gameObject.transform.Translate(Vector2.left * Time.deltaTime * Speed * RollPower);//left향으로 속도 * 구르는 힘 * 델타타임으로 위치 변경
        }
    }

    void SpecialAttack()//스페셜어택
    {
       
        
    }

    void ShootingTest()
    {
        Instantiate(bulletprefab1, transform.position, Quaternion.identity); //발사체 생성
    }

    void Attack()
    {
        Debug.Log("Attack진입");
        if (Change == 1)
        {
            Debug.Log("잔탄: " + weapon_1);
            if(weapon_1>0)
                weapon_1 -= 1;
            else if (weapon_1 <= 0)
            {
                temp = true;
            }
        }
        else if (Change == 2)
        {
            Debug.Log("잔탄: " + weapon_2);

            if (weapon_2 > 0)
                weapon_2 -= 1;
            else if (weapon_2 <= 0)
            {
                temp2 = true;
            }
        }
        else if (Change == 3)
        {
            Instantiate(bulletprefab3, transform.position, Quaternion.identity);
        }

    }
}
    
   