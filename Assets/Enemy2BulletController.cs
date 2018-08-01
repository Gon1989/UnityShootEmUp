using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2BulletController : MonoBehaviour {

    [Header("Bullet Speed")]
    public float speed;

    Rigidbody2D rb;
    PlayerController target; //player
    Vector2 direction;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindObjectOfType<PlayerController>();
        direction = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(direction.x, direction.y);


	}
	
	// Update is called once per frame
	void Update () {

        

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Debug.Log("HIT");
            Destroy(gameObject);
        }
    }

    

}
