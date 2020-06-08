using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThePlayer : MonoBehaviour {
    private float acceleration;
    private float turn;

    public float gravityModifier;
    public float speed = 20.0f;
    public float turnMultiplier = 2.0f;
    public bool turbo = false;
    public float nos = 100f;
    public Light turboLight;
    public bool isMoving;
    
    // Start is called before the first frame update

    void Start () {
        Physics.gravity *= gravityModifier;
        turboLight = GameObject.Find("Turbo Light").GetComponent<Light>();
        
        
    }

    // Update is called once per frame
    void Update () {
        acceleration = Input.GetAxis ("Vertical");

        isMoving = acceleration != 0;

        turn = Input.GetAxis ("Horizontal");



        //Movement COntrols
        transform.Translate (Vector3.left * speed * Time.deltaTime * acceleration * (turbo ? 2f: 1f));
        transform.Rotate (Vector3.up * turnMultiplier * Time.deltaTime * turn);


        // Reset Position if the car falls over
        if (Input.GetKeyDown (KeyCode.R)) {

            transform.rotation = Quaternion.Euler (0f, 0f, 0f);
            transform.position = new Vector3 (transform.position.x, 2.5f, transform.position.z);

        }
        //Turb turns on while B is pressed
        if (Input.GetKey(KeyCode.B))
        {
            if (nos > 0) {

                turbo = true;


                nos -= Time.deltaTime * 10;

            }
            else
            {
                turbo = false;
            }
        } else {
            turbo = false;
            if (nos < 100)
                nos += Time.deltaTime * 2;
        }
        //If turbo is truethen the light intensity is 50, 0 otherwise.
        turboLight.intensity = turbo ? 50 : 0;

    }

}