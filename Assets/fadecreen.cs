using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadecreen : MonoBehaviour
{
    public float sec;
    public string loading;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator countdown ()
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(loading);
        PlayerPrefs.SetString("lv1DONE","YES");
    }
}
