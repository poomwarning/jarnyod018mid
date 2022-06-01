using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootHP : MonoBehaviour
{
    float damage = 25; 
    float hp =500;
    public float HP  
    {get{return hp;} set{hp=value;}}
    public float DAMAGE  
    {get{return damage;} set{hp=damage;}}
   
   /* private void OnCollisionEnter(Collision other) 
    {
            if(other.transform.tag=="bullet")
            {
              Debug.Log("OOFHIT");
              //hp -= damage;
            }
    }*/
    
}
