using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
     최초작성일: 05/26/2018
     최초작성자: 배수구
     목적: 적 클래스
     */

public class anenmy : MonoBehaviour {

    private float health;
    private float movSpeed;
    private float atkSpeed;
    private float enermyX;
    private float enermyY;


    //체력관련 함수
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }



    //이동속도관련 함수
    public float MovSpeed
    {
        get
        {
            return movSpeed;
        }
        set
        {
            movSpeed = value;
        }
    }


    //공격속도관련 함수
    public float AtkSpeed
    {
        get
        {
            return atkSpeed;
        }
        set
        {
            atkSpeed = value;
        }
    }


    //적 x좌표
    public float EnermyX
    {
        get
        {
            return enermyX;
        }

        set
        {
            enermyX = value;
        }
    }


    //적 Y좌표
    public float EnermyY
    {
        get
        {
            return enermyY;
        }

        set
        {
            enermyY = value;
        }
    }


    //공격
    public int Attack() {


        return 1;

    }


    //적쫒기
    public int Chaese() {


        return 1;

    }

}
