using UnityEngine;
using System.Collections;


/*
 * 적구현하기
 * 배수한 제작
 * 
 * 
 */

public class anenmy_Triger : MonoBehaviour {
    public Transform target;
    public Vector3 direction;
    public float velocity = 0; //가속도 계산할 떄 쓰는데 잘 쓸지 모름
    // 가속도 지정 (추후 힘과 질량, 거리 등 계산해서 수정할 것)
    public float accelaration = 0.1f;  
    public float bigRadius = 10.0f;   // 인식 반경
    public float smallRadius = 1.0f;   // 공격 반경


    // Update is called once per frame
    void Update() {
        MoveToTarget();
    }

    public void MoveToTarget() {
        // Player의 현재 위치를 받아오는 Object
        target = GameObject.Find("Player").transform;
        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.position - transform.position).normalized;


        // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
        //velocity = (velocity + accelaration * Time.deltaTime);
        velocity = (accelaration);
        // Player와 객체 간의 거리 계산
        float distance = Vector3.Distance(target.position, transform.position);
        // 일정거리 안에 있을 시, 해당 방향으로 무빙
        if (smallRadius <= distance && distance <= bigRadius)
        {
            //this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
            //                                       transform.position.y + (direction.y * velocity),
            //                                         transform.position.z);

            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                   transform.position.y,
                                                     transform.position.z);

        }
        //공격범위 안에 있을 시
        else if(distance <= smallRadius)
        {
            Debug.Log("공격한다");
            //GetComponent("스크립트명").함수명();
            GameObject.Find("mushroom").GetComponent<anenmy>().Attack();


        }
        // 일정거리 밖에 있을 시, 속도 초기화 
        else
        {
            velocity = 0.0f;
        }
    }
}