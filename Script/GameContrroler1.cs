﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameContrroler1 : MonoBehaviour {
    
    enum State
    {
        Ready, Play
    }
    
    
    public Text SteminaLable;

    void Start
    {
        Ready();
    }
}
