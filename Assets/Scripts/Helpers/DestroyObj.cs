using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour {

    void FixedUpdate()
    {
        Destroy(gameObject, 0.5f);
    }

    

   
}
