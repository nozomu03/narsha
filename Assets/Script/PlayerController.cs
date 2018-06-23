using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float Speed = 7.0f;
    public float jumpForce = 300.0f;

    public bool isGrounded = false;//지금 땅에있음?
    public bool isJumping = false;//지금 점프중임?
    public LayerMask groundLayers;

    public Transform groundCheck;
    public int RollPower = 1;//구르는 힘
    public int health = 100;//체력
    public int stemina = 100;//스테미나
    public float grande_throw_pow = 0.5f;//던지는 힘
    public int countspecial = 0;
    public bool canshoot = true;
    public GameObject bulletprefab1;//1번무기 스프라이트
    public GameObject bulletprefab2;//2번무기 스프라이트
    public GameObject bulletprefab3;//3번무기 스프라이드 

    public GameObject laserPrefab; //발사할 레이저를 저장합니다.
    public bool canShoot = true; //레이저를 쏠 수 있는 상태인지 검사합니다.
    const float shootDelay = 0.5f; //레이저를 쏘는 주기를 정해줍니다.
    float shootTimer = 0; //시간을 잴 타이머를 만들어줍니다.

    public int Change = 1;//웨폰 스위칭 
    public int Specialmeter = 0;//특수무기 게이지
    private float groundCheckRadius = 1.2f;
    
    

    Rigidbody2D rb2D;


    /*
     최초작성일: 05/15/2018
     최초작성자: 경준이
     목적: 캐릭터 컨트롤러
     */
   
    void Start()
    {
        Debug.Log("정상적 실행 완료. 중력적용 완료");
        rb2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {

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
            //Attack();
            ShootingTest();
            
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
        if (canshoot)
        {
            Debug.Log("캔샷 통과 무기 분기점 진입");
            if (Change == 1)
            {
                Instantiate(bulletprefab1, transform.position, Quaternion.identity);
            }
            else if (Change == 2)
            {
                Instantiate(bulletprefab2, transform.position, Quaternion.identity);
            }
            else if (Change == 3)
            {
                Instantiate(bulletprefab3, transform.position, Quaternion.identity);
            }

        }
    }
    
    
}