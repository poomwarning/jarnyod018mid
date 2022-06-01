using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TimeformatDLL;
using System;

public class countdown : MonoBehaviour
{
   public Text showTime;
   ConvertToformat oof = new ConvertToformat();
   public float setupSEC;
   public static float sec;
   int getsec;
    private void Start() 
    {
        sec = setupSEC;
   }
    private void Update() 
    {
      if(sec>=0)
      {
         sec -= Time.deltaTime;
      }
      
      getsec = Convert.ToInt16(sec);
      oof.ConvertToformats(getsec);
      showTime.text = oof.show.ToString();
   }

}
