using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
public  class TestOrder : MonoBehaviour
{
  
  
    public  Text listarrayshow;
    public  int inputvaluescore;
    public  int Inputvaluescore {get{return inputvaluescore;} set{value = inputvaluescore;}}
      UnorderedInt array = new UnorderedInt();
   // public UnorderedInt oof {get{return array;} set{value = array;}}
    private  void Awake()
    {
       
        try
        {
        array.loadjson();
        
        }
        catch(Exception e)
        {
            Debug.Log("cant load json");
            
        }
        string arraystring = array.ToString();
            listarrayshow.text = arraystring;
    }
    private void Start() 
    {
        string arraystring = array.ToString();
        listarrayshow.text = arraystring;
        HP.listeneraddscore(testledboard);
        if(scoreandcount.score!=0)
        {
            testledboard(scoreandcount.score);
        }
    }
    
   /* void AddEmpty()
    {
        UnorderedInt array = new UnorderedInt();
        array.add(5);
        
        Debug.Log("AddEmpty : ");
        String arrayString = array.ToString();
        if(arrayString.Equals("5")&& array.Count ==1)
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("Failed! Expected : 5 but Actaul" + arrayString);
        }
    }*/
    public  void resetarray()
    {
       array.resetAll();
       string arraystring = array.ToString();
       listarrayshow.text = arraystring;
       array.dymictojason();
    }
    public  void ToFuckingstring()
    {
        string arraystring = array.ToString();
        listarrayshow.text = arraystring;
       
    }
    
    public void addarraylistener()
    {
        
    }
    public void testledboard(int oof)
    {
        array.add(oof);
        //array.add(Inputvaluescore);
        //string arraystring = array.ToString();
        //listarrayshow.text = arraystring;
        array.dymictojason();
    }
    public void testledboardv1()
    {
        array.add(inputvaluescore);
        //array.add(Inputvaluescore);
        string arraystring = array.ToString();
        listarrayshow.text = arraystring;
        array.dymictojason();
    }
     /*    void AddExpand()
    {
        UnorderedInt arrary = new UnorderedInt();
        arrary.add(5); arrary.add(7); arrary.add(2); arrary.add(9); arrary.add(1); arrary.add(4);
        Debug.Log("AddExpand : ");
        String arrayString = arrary.ToString();
        if (arrayString.Equals("5,7,2,9,1,4") && arrary.Count == 6)
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("FAILED! Expected : 5,7,2,9,1,4 but Actual : " + arrayString);
        }
    }*/
/*void RemoveFront()
    {
        UnorderedInt array = new UnorderedInt();
        array.add(5); array.add(7); array.add(2); array.add(9); array.add(1); array.add(4);
        bool removed = array.Remove(5);
        String arrayString = array.ToString();
        Debug.Log("RemoveFront: ");
        if (removed && arrayString.Equals("7, 2, 9, 1, 4") && array.Count == 5)
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("FAILED!!! Expected: 7, 2, 9, 1, 4 Actual: " + arrayString);
        }
    }*/
/*void testlastIndex()
        {
            UnorderedInt array = new UnorderedInt();
            array.add(6);
            array.add(9);
            array.add(6);
            array.add(6);
            array.add(9);
            array.add(9);
            String arrayString = array.LastIndexOf(6).ToString();
            Debug.Log(arrayString);
        }
         void sameIndex()
        {
            UnorderedInt array = new UnorderedInt();
            array.add(6);
            array.add(9);
            array.add(6);
            array.add(6);
            array.add(9);
            array.add(9);
            String arrayString = array.AllIndexOf(9);
            Debug.Log(arrayString);
        }*/




    
}
