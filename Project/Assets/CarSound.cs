using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
  
    public AudioSource[] clips;
    private bool isPlayerMoving;
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerMoving = GameObject.Find("Player").GetComponent<MoveThePlayer>().isMoving;
        
        if (isPlayerMoving)
        {
            clips[0].Stop();
            if (!clips[1].isPlaying)
            {
               
                clips[1].Play();
            }
        }
        else
        {
            clips[1].Stop();
            if (!clips[0].isPlaying)
            {

                
                clips[0].Play();
            }
        }

       
    }
}
