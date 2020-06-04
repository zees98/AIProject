using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMyVision : MonoBehaviour
{
    //how sensitive we are about vision/line of sight?
    public enum enmSensitivity{HIGH,LOW};

    //Var to check sensitivity
    public enmSensitivity sensitivity = enmSensitivity.HIGH;

    //Able to see the target right now?
    public bool targetInSight = false;

    //Field of Vision
    public float fieldofVision = 60f;

    //we need a reference to our target here
    private Transform target = null;

    //reference to our eye 
    public Transform eyes = null;

    //My Transform component
    public Transform npcTransform = null;

    //My Sphere collider
    private SphereCollider sphereCollider = null;

    //last known sighting of object?
    public Vector3 lastKnowSighting = Vector3.zero;
    // Start is called before the first frame update

    private void Awake()
    {
        npcTransform = GetComponent<Transform>();
        sphereCollider = GetComponent<SphereCollider>();
        lastKnowSighting = npcTransform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    bool InMyFieldOfVision()
    {
        Vector3 dirToTarget =  target.position -eyes.position;

        //Get angle between forward and view direction
        float angle = Vector3.Angle(eyes.forward,dirToTarget);
        
        //check if within field of view
        if(angle <= fieldofVision)
        {
            Debug.Log("Police Is Approaching");
            return true;
        }         
        else 
            return false;
        
    }

    //we need a function to check line of sight
    bool ClearLineofSight()
    {
        RaycastHit hit;

        if(Physics.Raycast(eyes.position,(target.position-eyes.position).normalized,out hit,sphereCollider.radius))
        {
            if(hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    void UpdateSight()
    {
        switch(sensitivity)
        {
            case enmSensitivity.HIGH:
                targetInSight = InMyFieldOfVision() && ClearLineofSight();
                break;
            case enmSensitivity.LOW:
                targetInSight = InMyFieldOfVision() || ClearLineofSight();
                break;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        UpdateSight();

        //Update last known sighting
        if(targetInSight)
        lastKnowSighting = target.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player")){
            Debug.Log("");
            return;
        }
            
        targetInSight = false;
        
    }

    void Start()
    {

        
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
