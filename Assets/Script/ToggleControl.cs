using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToggleControl : MonoBehaviour {

    // public Toggle toggle;

    // Use this for initialization

    String test = "";
    public bool togglebool = false;
    private ShowDialog Con_Dia;
    float time = 0.0f;
    public TextMesh mission;
    TextMesh Object_text = null;
    float time2 = 0f;

	void Start () {
        //GUIStyle style=null;
        //style.alignment = TextAnchor.UpperLeft;
        //Object_text.text = "<color=#FF0000>Object</color>";
        Con_Dia = GetComponent<ShowDialog>();
	}

    // Update is called once per frame
    void Update () {
        if(Con_Dia.dialog_end == true)
            time += Time.deltaTime;
        if (togglebool == true)
            time2 += Time.deltaTime;
        if (time2 >= 1.0f)
        {
            GoNextMap();
            togglebool = false;
            time2 = 0f;
        }
	}

    public void GoNextMap()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex+1<8) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else
        {
            SceneManager.LoadScene("theend");
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 230, 40), "");
        GUI.Label(new Rect(17, 10, 200, 30),  "<color=#ffffff>팁:</color>");    
        GUI.Toggle(new Rect(15, 30, 200, 30), togglebool, mission.text);

        GUI.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Finish"))
            togglebool = true;        
    }
}
