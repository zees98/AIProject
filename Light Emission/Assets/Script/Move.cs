using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   
    // Start is called before the first frame update
    public float s =50f;
    public float r =5f;
   public float gravityModifier;
   private Rigidbody playerRb;
    void Start()
    {
      
      Physics.gravity *= gravityModifier;
    
        
    }

    // Update is called once per frame
    void Update()
    {
        //we will move the car
        //  float v = Input.GetAxis("Vertical");

        
        transform.Translate(Vector3.forward*Time.deltaTime*150);
        //   float h = Input.GetAxis("Horizontal");
        // transform.Rotate(Vector3.up*r*Time.deltaTime*h);
        //transform.Translate(Vector3.right*Time.deltaTime*s*h);
       
    }
}
