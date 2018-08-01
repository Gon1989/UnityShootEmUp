using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    //function to destroy bullets making sure after a couple seconds
    [Header("Life time")]
    public float lifeTime;


	void FixedUpdate()
    {
        Destroy(gameObject, lifeTime);

    }


}
