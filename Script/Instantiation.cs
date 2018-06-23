using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Instantiation : MonoBehaviour {

    public Transform Mushroom;

    void Start() {


        Transform mushroom1 = Instantiate(Mushroom, new Vector3(0, 0, 0), Quaternion.identity);

    }
}

