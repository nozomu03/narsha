using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour {
    public float Cactus_Damage=0.5f;
    Player player;
    // Use this for initialization

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("cactus"))
        {
            Debug.Log(player.p_hp);
            player.Attacked(player.p_hp);
            Debug.Log("찔림:"+player.p_hp);
        }
    }

    void Start () {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
