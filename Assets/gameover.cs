using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameover : MonoBehaviour
{
    string sceneName ;
   
    private void Start() 
    {
    sceneName = SceneManager.GetActiveScene().name;
    }
   public void retry ()
   {
        SceneManager.LoadScene(sceneName);
   }
   public void menu()
   {
       SceneManager.LoadScene("Menu_Demo_Scene");
   }
}
