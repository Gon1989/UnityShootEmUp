using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectPlayer : MonoBehaviour
{
    public GameObject plane, plane2, plane3, plane4, plane5, panel, GameOverPanel;
    private GameObject selectedPlane;

    public void selection()
    {
        int selected =  PlayerPrefs.GetInt("plane", 0);
        if (selected==1){
            plane.SetActive(true);
            
            selectedPlane = plane;
        }
        else if (selected==2){
            plane2.SetActive(true);
            selectedPlane = plane2;
        }
        else if (selected==3){
            plane3.SetActive(true);
            selectedPlane = plane3;
        }
        else if (selected==4){
            plane4.SetActive(true);
            selectedPlane = plane4;
        }
        else if (selected == 5)
        {
            plane5.SetActive(true);
            selectedPlane = plane5;
        }
        panel.SetActive(false);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("out", 0) == 1)
        {
            Debug.Log("out");
            selectedPlane.SetActive(false);
            GameOverPanel.SetActive(true);
            PlayerPrefs.SetInt("out", 0);
        }
    }

}
