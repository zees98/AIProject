using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentMove : MonoBehaviour {
    // int frame = 0;
    private NavMeshAgent agent = null;
    public Transform destination = null;
    // Start is called before the first frame update
    void Start () {
        agent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update () {
        // print (frame++);
        agent.SetDestination (destination.position);
    }
}