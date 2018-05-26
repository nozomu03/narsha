using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anenmy : MonoBehaviour {

    private double health;
    private double movSpeed;
    private double atkSpeed;
    private int enermyX;
    private int enermyY;

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

    public int Attack() {


        return 1;

    }

    public int Chaese() {


        return 1;

    }

}
