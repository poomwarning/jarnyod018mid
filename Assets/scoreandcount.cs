using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreandcount : MonoBehaviour
{
    public Text scoretext;
    public Text zombietext;
    public static int score;
    public static int count;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "SCORE : " + score.ToString();
         zombietext.text = count.ToString();
        zombie.Zombielistener(Onkillzombie);
        count = 0;
        score = 0;
    }
    
    public void Onkillzombie(int oof)
    {
         count++; 
         score+= oof;
         scoretext.text = "SCORE : " + score.ToString();
         zombietext.text = count.ToString();
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
