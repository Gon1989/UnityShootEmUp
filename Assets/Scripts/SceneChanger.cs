using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   public void start()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
   }

   public void quit()
   {
        //Debug.Log("Quit");
        Application.Quit();
   }
}
