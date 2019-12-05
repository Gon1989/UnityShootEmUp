using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setPlane : MonoBehaviour
{
    public void selectplane1(){
        PlayerPrefs.SetInt("plane", 1); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void selectplane2(){
        PlayerPrefs.SetInt("plane", 2); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void selectplane3(){
        PlayerPrefs.SetInt("plane", 3); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void selectplane4()
    {
        PlayerPrefs.SetInt("plane", 4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void selectplane5()
    {
        PlayerPrefs.SetInt("plane", 5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void choseAxisPlane()
    {
        SceneManager.LoadScene(1);
    }


    public void choseAlliedPlane()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
