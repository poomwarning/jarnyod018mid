using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
 class UnorderedInt : intdynamic
{
    public UnorderedInt(): base() {}
    PlayerData scorearray = new PlayerData();
      public override void loadjson()
    {
        string jsonfromstring = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/saveFile.json");
        scorearray = JsonUtility.FromJson<PlayerData>(jsonfromstring);
        foreach(int x in scorearray.score)
        {
            add(x);
        }
        Array.Sort(items);
        Array.Reverse(items);
    }
    public override void resetAll()
    {
       foreach(int x in items)
       {
         int itemLocation = IndexOf(x);
        if(itemLocation ==-1) {}
        else
        {
            items[itemLocation] = items[count-1];
            count--;
        }
       }
    }
    public override void dymictojason()
    {
        
        scorearray.score = Items;
        Array.Sort(scorearray.score);
        Array.Reverse(scorearray.score);
        string json = JsonUtility.ToJson(scorearray);
       
        File.WriteAllText(Application.dataPath + "/StreamingAssets"+ "/saveFile.json", json);
    }
    public override void add(int item)
    {
       if(count==items.Length){Expand();}
       items[count] = item ;
       count++;
    }
    public override int IndexOf(int item)
    {
       for(int i =0; i<count;i++)
       {
           if(items[i]==item){return i;}
       }
       return -1;
    }
    public override bool Remove(int item)
    {
        int itemLocation = IndexOf(item);
        if(itemLocation ==-1) {return false;}
        else
        {
            items[itemLocation] = items[count-1];
            count--;
            return true;
        }
    }
    public override int LastIndexOf(int item)
    {
        for(int i = count-1; i >= 0; i--){
            if(items[i] == item){
                return i;
            }
        }
        return -1;
    }

    public override string AllIndexOf(int item)
    {
        List<int> duplicateItem = new List<int>();
        for(int i = 0; i < count; i++){
            if(items[i] == item){
                duplicateItem.Add(i);
            }
        }
        
        if(duplicateItem != null){
            return string.Join(",",duplicateItem);
        }else{
            return "Empty List";
        }
    }
   

}
 public class PlayerData
	{
		public  int[] score;
        
        
    }
