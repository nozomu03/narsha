using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
