using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    TestOrder ggez;
    public bool lv1pass;
    public bool lv2pass;
    string state ;
    public Animator MENUMOVE;
    public Button LV1 ;
    public Button LV2 ;
    public GameObject menu;
    public GameObject Leaderboard;
    public GameObject gamelevel;
    // Start is called before the first frame update
    void Start()
    {
       
        ggez = GameObject.Find("dymicarray").GetComponent<TestOrder>();
        PlayerPrefs.SetString("introDONE","YES");
        if(PlayerPrefs.GetString("lv1DONE")==null)
        {
             PlayerPrefs.SetString("lv1DONE","NO");
        }
        if(PlayerPrefs.GetString("lv2DONE")==null)
        {
             PlayerPrefs.SetString("lv2DONE","NO");
        }
        //Debug.Log(PlayerPrefs.GetString("lv1DONE"));
       PlayerPrefs.Save();
        state ="1";
    }

    // Update is called once per frame
    void Update()
    {
        if(lv1pass==true)
        {
            LV1.interactable=true;
        }
        else
        {
            LV1.interactable=false;
        }
        if(lv2pass==true)
        {
            LV2.interactable=true;
        }
        else
        {
             LV2.interactable=false;
        }
        if(PlayerPrefs.GetString("lv1DONE")=="YES")
        {
            lv1pass = true;
        }
        if(PlayerPrefs.GetString("lv2DONE")=="YES")
        {
            lv2pass = true;
        }
        //Debug.Log(PlayerPrefs.GetString("lv1DONE"));
    }
    public void play()
    {
         state = "2";
        menu.SetActive(false);
       
        MENUMOVE.SetBool("GOTOLEVEL",true);
        StartCoroutine(cooldownMENU());
    }
    public void ledboard()
    {
         state = "3";
        menu.SetActive(false);
        ggez.ToFuckingstring();
        MENUMOVE.SetBool("GOTOLEVEL",true);
        StartCoroutine(cooldownMENU());
    }
    public void intro()
    {
        SceneManager.LoadScene("Plane_Demo_Scene");
    }
    public void LVONE()
    {
        SceneManager.LoadScene("lv1");
    }
    public void LVTWO()
    {
        SceneManager.LoadScene("endless");
    }
    public void RESETSAVE()
    {
        ggez.resetarray();
       PlayerPrefs.DeleteAll();
       
       SceneManager.LoadScene("Menu_Demo_Scene");
    }
    IEnumerator cooldownMENU()
    {
        yield return new WaitForSeconds(1);
        if(state == "2")
        {
             gamelevel.SetActive(true);
        }
        else if(state == "1")
        {
            menu.SetActive(true);
        }
        else if(state =="3")
        {
            Leaderboard.SetActive(true);
        }
      
    }
    public void backtoM()
    {
        state = "1";
        gamelevel.SetActive(false);
        Leaderboard.SetActive(false);
        MENUMOVE.SetBool("GOTOLEVEL",false);
        StartCoroutine(cooldownMENU());
    }
}
