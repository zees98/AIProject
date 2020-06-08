using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    private NavMeshAgent agent;
    public float chaseDistance = 20.0f;
    private Transform finish;
    private float maxDamage = 20f;
    private float stoppingDistance = 5f;
    void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        finish = GameObject.Find("Finish").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        

        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance <= chaseDistance)
        {
            agent.SetDestination(player.transform.position);
            agent.isStopped = false;
            if(distance <= stoppingDistance)
            {
                agent.isStopped = true;
            }
            print(agent.isStopped);

           // while (agent.pathPending) { }
        }
        else
        {
            agent.SetDestination(finish.position);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<HealthCode>().health -= Time.deltaTime * 20f;
        }
    }
}
