using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
      
     
    
        
    }
       private void OnTriggerStay(Collider other)
    {
        Debug.Log("YOU WON");
    }

    // Update is called once per frame
    void Update()
    {
      
       
    }
}
