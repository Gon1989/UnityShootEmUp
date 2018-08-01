using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundController : MonoBehaviour {

    public float speed;
    Vector3 startPos;



	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate((new Vector3(0f, -1f, 0)) * speed * Time.deltaTime); 
        //check if we finish to display the sprite background complete
        //if we did attach the new one to a precise coordinate for a smooth effect
        if (transform.position.y < -146.3)
        {
            transform.position = startPos;
        }

	}
}
