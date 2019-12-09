using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy1Controller : MonoBehaviour {

    //References
    private SpawnController gameController;

    [Header("Settings")]
    public int hp;
    public float speed;

    [Header("Type of Bullet")]
    public GameObject bullet;

    [Header("Bullet Position")]
    public GameObject BulletPosEnemy2;

    [Header("Bullet Pattern")]
    [SerializeField]
    private float startTimer = 5;
    [SerializeField]
    private float timer = 2f;

    [Header("Type of Explosion")]
    public GameObject explosionAnim; //reference to explosion when destroyed

    [Header("Score")]
    public int scoreValue;

    // Use this for initialization
    void Start () {
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        if (gameControllerObj != null) //if we found it
        {
            
            gameController = gameControllerObj.GetComponent<SpawnController>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Enemy " + hp);
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;//update 

        //get the lower out bound camera position
        Vector2 bottom = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //bottom
        
        //check if goes outside bottom camera
        if (transform.position.y < bottom.y)
        {
            Destroy(gameObject); //destroy
        }

        //death
        if (hp <= 0)
        {
            //add 10 to the score accessing ScoreController class
            Debug.Log("Died");
            ScoreController.scoreValue += 10;
            Destroy(gameObject); //destroy   
            if (gameObject.name == "Enemy2")
            {
                if (SceneManager.GetActiveScene().buildIndex != 5)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }

            }
        }

        //call function to check firing time rate
        checkTimeToFire();


    }

    //function to collide
    void OnTriggerEnter2D(Collider2D col)
    {
        //collide with bullet or player
        if (col.gameObject.tag == "PlayerBulletTag" || col.gameObject.tag == "Player")
        {
            explosion();
            hp -= 1;   
        }

    }

    //function to instantiate explosion animation
    void explosion()
    {
        GameObject explosion = (GameObject)Instantiate(explosionAnim);
        explosion.transform.position = transform.position;       
    }

    //function to delay
    void checkTimeToFire()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Instantiate(bullet, BulletPosEnemy2.transform.position, Quaternion.identity); //instantiate
            timer = startTimer; //rest timer back
        }
    }



}
