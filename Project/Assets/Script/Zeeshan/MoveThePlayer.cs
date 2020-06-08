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

        transform.Translate (Vector3.left * speed * Time.deltaTime * acceleration * (turbo ? 2f: 1f));
        transform.Rotate (Vector3.up * turnMultiplier * Time.deltaTime * turn);

        if (Input.GetKeyDown (KeyCode.R)) {

            transform.rotation = Quaternion.Euler (0f, 0f, 0f);
            transform.position = new Vector3 (transform.position.x, 2.5f, transform.position.z);

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            turbo = !turbo;
            
        }
        
        turboLight.intensity = turbo ? 50 : 0;

    }
}