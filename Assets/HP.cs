using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class HP : MonoBehaviour
{
   
    string sceneName;
    
    public GameObject player;
    public GameObject HUB;
    public GameObject gameover;
    
    public RawImage bloodoverlay;
    public static float currentHp;
    public static bool regen ;
    public static bool oof;
    public float maxHp ;
    public float showhp;
    Color temp;
    // Start is called before the first frame update
     static arrayEvent ArrayEvent = new arrayEvent();
   public static void listeneraddscore(UnityAction<int> listener)
   {
       ArrayEvent.AddListener(listener);
   }
    void Start()
    {
       oof = false;
        currentHp=maxHp;
        temp = bloodoverlay.color;
    // ggez.testledboard(scoreandcount.score);   
        bloodoverlay.color = temp;
//        ggez = GameObject.Find("dymicarray").GetComponent<TestOrder>();
    }

    // Update is called once per frame
    void Update()
    { 
         if(regen==true && currentHp<=maxHp && oof==false)
        {
            currentHp += Time.deltaTime*10;
        }
        if(currentHp<=0||countdown.sec<=0)
        {
            oof = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.SetActive(false);
            HUB.SetActive(false);
            gameover.SetActive(true);
            addscore();
        }
     // Debug.Log(regen);
      showhp = currentHp;
     
       temp.a = (((currentHp/maxHp)*100)-100)/-100;
       bloodoverlay.color = temp;
    }
    public static void takedamage(float income)
    {
       
        currentHp -= income;
    }
    public  void addscore()
    {
        sceneName = SceneManager.GetActiveScene().name;
     if(sceneName=="endless")
     {
         ArrayEvent.Invoke(scoreandcount.score);
           Debug.Log("added");
     
     }
       
    }
    
}
