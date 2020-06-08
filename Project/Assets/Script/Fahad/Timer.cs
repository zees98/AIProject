using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float currenttime = 0f;
    public float startingTime =0f;

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
        currenttime += 1*Time.deltaTime;
        timetext.text = currenttime.ToString("0");
       
       

    }
}
