using System.Collections.Generic;
using System.Text;
using System;

abstract class intdynamic 
{
   const int ExpandMultipleFactor = 2;
   protected int[] items;
   protected int count;
   protected intdynamic()
   {
       items = new int[4]; count = 0;
   }
   public abstract void resetAll();
   public abstract void dymictojason();
   public abstract void loadjson();
    public abstract int LastIndexOf(int item) ;
    public abstract string AllIndexOf(int item);
   public abstract void add(int item);
   public abstract bool Remove(int item);
   public abstract int IndexOf(int item);
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i<count;i++)
        {
          if(items[i]!=0)
          {
            builder.Append(items[i]);
            if(i<count-1 ) 
            {
                builder.Append("\n");
            }
          }

        }
        return builder.ToString();
    }
    /*public override void Add(int item)
    {
        item[count] = item;
        count++;
    }*/
    protected void Expand()
    {
        int[] newItems = new int[items.Length * ExpandMultipleFactor];
        for(int i = 0; i<items.Length;i++)
        {
            newItems[i] = items[i];
        }
        items = newItems;
    }
    public int Count {get{return count;}}
    public int[] Items {get{return items;} set{value = items;}}
    public void Clear(){count=0;}

}
