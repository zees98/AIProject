using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float acceleration;
    private float turn;
    
     public float gravityModifier;
    public float speed =  20.0f;
    public float turnMultiplier = 2.0f;
    // Start is called before the first frame update

    void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Input.GetAxis("Vertical");

        turn = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * acceleration);
        transform.Rotate(Vector3.up * turnMultiplier * Time.deltaTime * turn);

    }
}
