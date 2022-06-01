using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class random : MonoBehaviour
{
public int howmuchzombie;
public GameObject area;
public GameObject[] zombie;

public Quaternion test;

CSV zombiedatas;

public static int limitzombie;

 private void Awake() 
 {
   zombiedatas = GameObject.Find("cSV").GetComponent<CSV>();
 }

  // public Vector3 Center;
  // public Vector3 Size;
    // Start is called before the first frame update
    

    void Start()
    {
      
        InvokeRepeating("SpawnZOMBIE",2f,0.3f);
       // Center = center.GetComponent<Vector3>();
       // Size = size.GetComponent<Vector3>();
    }

    // Update is called once per frame
 
     private void OnDrawGizmosSelected() 
      {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(area.transform.position,area.transform.localScale);
    }
    public void SpawnZOMBIE()
    {
      string className = "";
      if(limitzombie<=howmuchzombie)
      {
         int rand = UnityEngine.Random.Range(0,zombie.Length);
        Vector3 pos = area.transform.position + new Vector3(UnityEngine.Random.Range(-area.transform.localScale.x/2,area.transform.localScale.x/2),UnityEngine.Random.Range(-area.transform.localScale.y/2,area.transform.localScale.y/2),UnityEngine.Random.Range(-area.transform.localScale.z/2,area.transform.localScale.z/2));
         
         try
         {
           className = zombie[rand].GetComponentInChildren<zombie>().GetType().Name;
         }
         catch(Exception oof)
         {
           className = zombie[rand].GetComponent<zombie>().GetType().Name;
         }
          
         switch (className)
            {
                case "zombie":
                    zombiedatas.targetData = zombiedatas.targets["zombie"]; 
                    break;
                case "zombieriot":
                    zombiedatas.targetData = zombiedatas.targets["zombieriot"];
                    break;
                case "zombiearmy":
                    zombiedatas.targetData = zombiedatas.targets["zombiearmy"];
                    break;
                default:
                    break;
            }
            zombie[rand].GetComponentInChildren<zombie>().speed = zombiedatas.targetData.SPEED;
            zombie[rand].GetComponentInChildren<zombie>().zombieHP = zombiedatas.targetData.HP;
            zombie[rand].GetComponentInChildren<zombie>().Zdamage = zombiedatas.targetData.DAMAGE;
        Instantiate(zombie[rand],pos,zombie[rand].transform.rotation);
        limitzombie++;
      }
       
    }
   
}
