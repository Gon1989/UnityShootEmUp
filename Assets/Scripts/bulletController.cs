using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

    [Header("Settings")]
    public float speed = 0f;

    //init
    void Start()
    {
        //speed = 6f;
    }

    //every frame
    void Update()
    {
        Vector2 position = transform.position; //get bullet position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime); //move bullet
        transform.position = position; //apply new speed

        //destroy bullet when it's outside boundaries
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        //check if is outside
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);   //detroy when outside
        }

    }

    //function to check collision with enemies
    void OnTriggerEnter2D(Collider2D col)
    {
        //check if we collide with enemy
        if (col.gameObject.tag == "EnemyShipTag")
        {
            //make it shake
                            //duration/amount
            CameraShake.Shake(0.10f, 0.10f);
            Destroy(gameObject); //destroy
        }
    }


}
