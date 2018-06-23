using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : anenmy {

    private double sAtk;
    private double sRange;

    public double SRange
    {
        get
        {
            return sRange;
        }

        set
        {
            sRange = value;
        }
    }

    public double SAtk
    {
        get
        {
            return sAtk;
        }

        set
        {
            sAtk = value;
        }
    }
}
