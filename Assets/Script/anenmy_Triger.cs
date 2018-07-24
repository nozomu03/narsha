
using UnityEngine;
using System.Collections;


/*
 * 적구현하기
 * 배수한 제작
 * 
 * 
 */

public class anenmy_Triger : MonoBehaviour
{
    public Transform target;
    public Vector3 direction;
    //public float velocity = 0; //가속도 계산할 떄 쓰는데 잘 쓸지 모름
    //// 가속도 지정 (추후 힘과 질량, 거리 등 계산해서 수정할 것)
    public float movSpeed = 0.1f;
    public float bigRadius = 10.0f;   // 인식 반경
    public float smallRadius = 1.0f;   // 공격 반경
    Animator anim;

    int random=0;

    float minus;

    public float health = 100f;
    public float atkSpeed = 1.0f;
    public float atak = 10.0f;
    Player p_con;
    ShowDialog showDialog;

    private bool left = true;
    private float timer = 1000f;

    public GameObject hpbar;

    void Start()
    {
        anim = GetComponent<Animator>();
        showDialog = GameObject.Find("Cowboy1").GetComponent<ShowDialog>();
        p_con = GameObject.Find("Cowboy1").GetComponent<Player>();
        Transform size=null;
        minus = health / 20;
        minus = 24 / minus;
        hpbar.transform.localScale = new Vector3(24f, 2f, 0f);
        //Debug.Log(size.transform.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    void sturnRandom()
    {
        random = Random.Range(1, 5);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("이벤트");
        if (other.gameObject.tag.Equals("Bullet"))
        {   
            Debug.Log("충돌");
            subHealth(20f);
            Destroy(other.gameObject);
        }
    }

    public void MoveToTarget()
    {
        timer += Time.deltaTime;
        if (health <= 0)
        {
            anim.SetBool("die", true);
            Destroy(gameObject, 2.3f);
        }


        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.position - transform.position).normalized;



        // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
        //velocity = (velocity + accelaration * Time.deltaTime);
        //velocity = (movSpeed);
        // Player와 객체 간의 거리 계산


        float distance = Vector2.Distance(target.position, transform.position);
        if (target.position.x > this.transform.position.x && left == false)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            left = true;
        }
        else if (target.position.x < this.transform.position.x && left == true)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            left = false;
        }


        // 일정거리 안에 있을 시, 해당 방향으로 무빙
        if (smallRadius <= distance && distance <= bigRadius)
        {
            anim.SetBool("attack", false);
            anim.SetBool("run", true);
            //this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
            //                                       transform.position.y + (direction.y * velocity),
            //                                         transform.position.z);

            transform.position = new Vector3(transform.position.x + (direction.x * movSpeed),
                                                   transform.position.y,
                                                     transform.position.z);

        }
        //공격범위 안에 있을 시
        else if (distance <= smallRadius && anim.GetBool("die")==false)
        {
            if (timer > 1.0 / atkSpeed)
            {
                anim.SetFloat("atkSpeed", atkSpeed);
                anim.SetBool("run", false);
                anim.SetBool("attack", true);
                p_con.Attacked(atak);
                if (gameObject.tag.Equals("mace"))
                {
                    Debug.Log("메이스 타격");
                    sturnRandom();
                    if(random == 1)
                        p_con.isSturn = true;
                }
                //Debug.Log("공격한다");
                timer = 0;
            }

        }
        // 일정거리 밖에 있을 시, 속도 초기화 
        else
        {
            anim.SetBool("attack", false);
            anim.SetBool("run", false);
        }
    }

    public void subHealth(float damge)
    {
        health -= damge;
        if (hpbar.transform.localScale.x - minus <= 0)
        {
            hpbar.transform.localScale = new Vector3(hpbar.transform.localScale.x - hpbar.transform.localScale.x, hpbar.transform.localScale.y, 0);
        }
        else
        {
            hpbar.transform.localScale = new Vector3(hpbar.transform.localScale.x - minus, hpbar.transform.localScale.y, 0);
        }
    }
}