using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float currenttime = 59f;
    public float startingTime =59f;

     Text timetext;

    void Start()
    {
        timetext = GetComponent<Text> ();
        currenttime = startingTime;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        //  Gameover.gameover="";
        currenttime -= 1*Time.deltaTime;
        timetext.text = currenttime.ToString("0");
        if(currenttime<0){
            Debug.Log("FFF");
             timetext.text = 0f.ToString("0");
        }
       

    }
}
