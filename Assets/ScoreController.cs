using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour {

    public static int scoreValue = 0;
    Text score, HP;


	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        score.text = "Score: " + scoreValue;
        if (scoreValue >= PlayerPrefs.GetInt("score", 0))
        {
            PlayerPrefs.SetInt("score", scoreValue);
        }
    }

    



}
