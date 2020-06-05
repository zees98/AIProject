using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float acceleration;
    private float turn;
    float rotationreset = 1.0f;
    
     public float gravityModifier;
    public float speed =  20.0f;
    public float turnMultiplier = 2.0f;

    public Quaternion orginalrotation;
    // Start is called before the first frame update

    void Start()
    {
        Physics.gravity *= gravityModifier;
        orginalrotation = transform.rotation;
    }

    //   private void OnTriggerStay(Collider other)
    // {
    //     Debug.Log("YOU WON");
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)  )
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,orginalrotation,Time.time*rotationreset);
        }
        acceleration = Input.GetAxis("Vertical");

        turn = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * acceleration);
        transform.Rotate(Vector3.up * turnMultiplier * Time.deltaTime * turn);

    }
}
