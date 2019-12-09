using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;

    void Update()
    {
        //Debug.Log("Score");
        score.text = "Highest: " + PlayerPrefs.GetInt("score", 0);
    }
}
