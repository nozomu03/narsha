using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

public class Location : MonoBehaviour {
    public GameObject block;
    static List<float> BlockList_x = new List<float>();
    static List<float> BlockList_y = new List<float>();
    int a = 0;

    //-6.15~54.97 +2

    // Use this for initialization
    void Start()
    {
        for(int i=-30; i<=2000; i+=2)
        {
            BlockList_x.Add(i);
            Debug.Log(BlockList_x[a]);
            a++;
        }
        foreach(float tempposition in BlockList_x){
            Instantiate(block, new Vector2(tempposition, -13), Quaternion.identity);
        }
        Instantiate(block, new Vector2(BlockList_x[10], BlockList_y[0]), Quaternion.identity);
    }
}