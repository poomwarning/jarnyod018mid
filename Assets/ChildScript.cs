using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
   public GameObject parent;
   
  /* public static  bool hit;
  
   public  void OnCollisionEnter(Collision other) 
   {
    if(other.transform.tag=="bullet")
    {
      hit = true;
    }
    else
    {
       hit = false;
    }    
   }
   void CollisionFromChild(bool hit)
   {
      if(hit=true)
      {
         
      }
      else if(hit=false)
      {

      }
   }*/
    private void OnCollisionEnter(Collision other)
     {
        
        if(other.transform.tag=="bullet")
        {
            if(this.transform.tag=="HEAD")
           {
            parent.transform.GetComponent<zombie>().Headshot(this);
          //  parent.transform.GetComponent<zombieriot>().Headshot(this);
           
           
          
           }
           parent.transform.GetComponent<zombie>().CollisionDetected(this);
          // parent.transform.GetComponent<zombieriot>().CollisionDetected(this);
        }

   }
}
 




