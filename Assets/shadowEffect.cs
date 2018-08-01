using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] //make sure paret has always sprite renderer

public class shadowEffect : MonoBehaviour {

    public Vector3 Offset = new Vector3(-0.1f, -0.1f); //shadow position
    public Material Material;
    GameObject shadow;


    void Start()
    {
        shadow = new GameObject("Shadow");
        shadow.transform.parent = transform; //make shadow a child of the current obj

        shadow.transform.localPosition = Offset; //position
        shadow.transform.localRotation = Quaternion.identity; //local rotation

        SpriteRenderer renderer = GetComponent<SpriteRenderer>(); //get parent sprite renderer component 
        SpriteRenderer sr = shadow.AddComponent<SpriteRenderer>(); //add sprite renderer to the shadow component
        sr.sprite = renderer.sprite; //parent sprite

        sr.material = Material; //set material to a mat that we will pass thru inspector

        //render shadows behind sprite
        sr.sortingLayerName = renderer.sortingLayerName;
        sr.sortingOrder = renderer.sortingOrder - 1;


    }

    void LateUpdate()
    {
        //sprite always maintain position at the end
        shadow.transform.localPosition = Offset;

    }





}
