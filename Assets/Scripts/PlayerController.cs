using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [Header("Player Movement")]
    public float speed;
    public int hp;
    //bullets position
    public GameObject PlayerBullet;
    public GameObject bullet1; //left position
    public GameObject bullet2; //right position
    public Text HP;



	// Use this for initialization
	void Start () 
    {
        PlayerPrefs.SetInt("out", 0);
    }
	
	// Update is called once per frame
	void Update () {

        HP.text = "HP: " + hp; 

        //Movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x , y).normalized;

        //we call the method to move
        move(direction);

        //fire
        if (Input.GetKeyDown("space"))
        {
            
            fire();
        }
          if (hp <= 0)
        {
            //if hp is out
            PlayerPrefs.SetInt("out", 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //collide with bullet or player
        //Debug.Log(1);
        if (collision.gameObject.CompareTag("EnemyShipTag"))
        {
            hp -= 5;   
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            hp -= 10;
        }

    }
    //function to move player
    void move(Vector2 direction)
    {
        //bottom left corner
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //top right corner
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //subtract limit player sprite half width 
        max.x = max.x - 0.225f;
        //add limit player sprite half width 
        max.x = max.x + 0.225f;

        //subtract the player sprite half height
        max.y = max.y - 0.285f;
        //add player sprite sprite half height
        max.y = max.y + 0.285f;

        //Get player current position
        Vector2 pos = transform.position;
        //apply new position
        pos += direction * speed * Time.deltaTime;

        //limit position not outside screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

       

        //update player position
        transform.position = pos;

    }

    //function to fire your weapon
    void fire()
    {
        //Instantiate(EntityPrefab, Position, Quaternion.identity) as GameObject;??????
        GameObject bulletL = (GameObject)Instantiate(PlayerBullet);
        bulletL.transform.position = bullet1.transform.position; //bullet initial position

        GameObject bulletR = (GameObject)Instantiate(PlayerBullet);
        bulletR.transform.position = bullet2.transform.position; //bullet initial position

    }




}
