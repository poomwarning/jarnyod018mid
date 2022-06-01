using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class CSV : MonoBehaviour
{
    public zombie[] manytarget;
     public string ConfFileName = "confData.csv";
    public Dictionary<string, target> targets = new Dictionary<string, target>();
     float Health = 0f;
     float fast = 30;
      float hurt = 0;
    public  target targetData ;
     private void Awake()
    {
       targetData = new target(Health, fast,hurt);
        GameObject[] zombietype = GameObject.FindGameObjectsWithTag("Target");
        manytarget = new zombie[zombietype.Length];
        for(int i =0 ; i< zombietype.Length;++i)
        {
            manytarget[i] = zombietype[i].GetComponent<zombie>();
        }
         Debug.Log(zombietype.Length);
        ReadData();
    }

    private void ReadData()
    {
        StreamReader input = null;
        string path = "Assets/StreamingAssets";
        try
        {
            input = File.OpenText(Path.Combine(path,
                                        ConfFileName));
            string name = input.ReadLine();
            string values = input.ReadLine();
            while (values != null)
            {
                AssignData(values);
                values = input.ReadLine();
            }
        }
        catch (Exception ex) { Debug.Log(ex.Message); }
        finally { if (input != null) input.Close(); }
    }
     void AssignData(string values)
    {
        string[] data = values.Split(',');
        int no = int.Parse(data[0]);
        string targetName = data[1];
        float hp = int.Parse(data[2]);
        float Speed = float.Parse(data[3]);
        float Damage  = float.Parse(data[4]);
      
        target enemy = new target( hp,Speed,Damage);
        targets.Add(targetName, enemy);
    }
     void Start()
    {
        if (manytarget == null) return;
      
        int i = 0;
        foreach (zombie spawn in manytarget)
        {
            
            string className = manytarget[i].GetType().Name;
           // float Health = 0f;
           // float fast = 30;
           // float hurt = 0;
           // target targetData = new target(Health, fast,hurt);
            switch (className)
            {
                case "zombie":
                    targetData = targets["zombie"]; 
                    break;
                case "zombieriot":
                    targetData = targets["zombieriot"];
                    break;
                case "zombiearmy":
                    targetData = targets["zombiearmy"];
                    break;
                default:
                    break;
            }
           // manytarget[i].score = targetData.Score;
           // manytarget[i].xSize = targetData.Size;
          //  manytarget[i].minTime = targetData.Min;
          //  manytarget[i].maxTime = targetData.Max;
              manytarget[i].speed = targetData.SPEED;
              manytarget[i].zombieHP = targetData.HP;
              manytarget[i].Zdamage = targetData.DAMAGE;
             i++;


            
        }
    }

}
