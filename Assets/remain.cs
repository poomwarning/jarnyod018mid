using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remain : MonoBehaviour
{
    public GameObject timeer;
    
    public Text showremain;
    public GameObject heli;
    
    public static int zombie,maxzombie;
    GameObject[] zombies;
    // Start is called before the first frame update
     private void Awake() 
     {
          zombies = GameObject.FindGameObjectsWithTag("Target");
    }
    void Start()
    {
        maxzombie = zombies.Length;
        zombie = maxzombie;
    }

    // Update is called once per frame
    void Update()
    {   
        showremain.text = zombie+"/"+maxzombie;
        if(zombie<=0)
        {
            heli.SetActive(true);
            timeer.SetActive(false);
        }
    }
}
