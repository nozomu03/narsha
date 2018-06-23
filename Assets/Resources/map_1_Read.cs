using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_1_Read : MonoBehaviour {

    public Transform Mushroom;

    void Start() {
        List<Dictionary<string, object>> data = CSVReader.Read("map_1");
        

        for (var i = 0; i < data.Count; i++)
        {
            Debug.Log("index " + (i).ToString() + " : " + data[i]["type"] + " " + data[i]["x"] + " " + data[i]["y"]);
            float x = (int)data[i]["x"];
            float y = (int)data[i]["y"];

                
            Transform mushroom1 = Instantiate(Mushroom, new Vector3(x, y, 0), Quaternion.identity);
        }

    }
}
