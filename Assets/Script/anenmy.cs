using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class anenmy : MonoBehaviour {

    private double health;
    private double movSpeed;
    private double atkSpeed;
    private int enermyX;
    private int enermyY;


    //체력관련 함수
    public double Health
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
    public double MovSpeed
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
    public double AtkSpeed
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
    public int EnermyX
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
    public int EnermyY
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

=======
/*
     최초작성일: 05/26/2018
     최초작성자: 배수구
     목적: 적 클래스
     */

public class anenmy : MonoBehaviour {

    public float health;
    public float movSpeed;
    public float atkSpeed;
    
    public void Start() {
        
    }

    


    




>>>>>>> d8b8e1b54e3a25939dac1a24dfcf9c0df0180292
}
