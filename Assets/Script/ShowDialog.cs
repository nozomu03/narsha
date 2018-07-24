using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShowDialog : MonoBehaviour {
    public TextMesh dialog;
    [TextArea]
    public String dialog_message="기분 나쁜 곳이다.\n어서 빠져나가자.";
    public bool dialog_end = false;

    String RealMessage = "";
	// Use this for initialization
	void Start () {
      // StartCoroutine(ShowText());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public  void PrintDialog()
    {
       foreach(char temp in dialog_message)
        {
            RealMessage = RealMessage + "" + temp;
            dialog.text = RealMessage;
            Debug.Log(dialog.text);  
        }
    }

    IEnumerator ShowText()
    {
        for(int i=0; i<dialog_message.Length; i++)
        {
            RealMessage = dialog_message.Substring(0, i);
            dialog.text = RealMessage;
            yield return new WaitForSeconds(0.1f);
            if (i == dialog_message.Length-1)
                dialog_end = true;
        }
    }
}
