using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    private float acceleration;
    private float turn;

    private float point = 0f;

    float rotationreset = 1.0f;

    private GameObject coin;

    Text score;
    
     public float gravityModifier;
    public float speed =  20.0f;
    public float turnMultiplier = 2.0f;

    public Quaternion orginalrotation;
    // Start is called before the first frame update

    void Start()
    {
        coin = GameObject.FindGameObjectWithTag("coin");
        score = GameObject.Find("P").GetComponent<Text>();
       
        Physics.gravity *= gravityModifier;
        orginalrotation = transform.rotation;
        // score.text = "0";
        // score.text = "0";
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

     private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("coin"))
        {
            point +=1;
            Destroy(other.gameObject);
           
            score.text = "Score: "+point.ToString("0");


        }
       

    }
}
