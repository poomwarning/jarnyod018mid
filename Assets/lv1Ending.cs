using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lv1Ending : MonoBehaviour
{
   public GameObject fade;
   public void setactiveFade()
   {
       fade.SetActive(true);
   }
   public void fadeGomenu()
   {
       Cursor.visible = true;
       Cursor.lockState = CursorLockMode.None;
        PlayerPrefs.SetString("lv2DONE","YES");
       SceneManager.LoadScene("Menu_Demo_Scene");
       
   }
}
