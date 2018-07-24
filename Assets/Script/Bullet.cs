using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private const float moveSpeed = 50.45f;

    Player player;

    float range = 0.0f;

    // Use this for initialization

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Enermy"))
        {
            Destroy(gameObject);
            
        }
        if (collision.gameObject.tag.Equals("something"))
        {
            Debug.Log("통과 중");
        }
    }

    void Start () {
        player = GameObject.Find("Cowboy1").GetComponent<Player>();
        range = player.dummy1.position.x;
        range += 10f;
    }

    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime;
        transform.Translate(new Vector2(moveX, 0));
        ///Debug.Log(range +":"+this.transform.position.x);
        if (transform.position.x >= range)
            Destroy(gameObject);
    }
}
