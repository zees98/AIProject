using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_FSM : MonoBehaviour
{
    public enum Enemy_State{PATROL,CHASE,ATTACK};
  

    private Enemy_State currentState;

    //we need a function to access the current state
    public Enemy_State CurrentState
    {
        get{ return currentState;}
        set
        {
            currentState = value;
            //stop all co-routines
            StopAllCoroutines();

            switch(currentState)
            {
                case Enemy_State.PATROL:
                    StartCoroutine(EnemyPatrol());
                    break;
                case Enemy_State.CHASE:
                    StartCoroutine(EnemyChase());
                    break;
                case Enemy_State.ATTACK:
                    StartCoroutine(EnemyAttack());
                    break;
            }
        }
    }
    private CheckMyVision checkMyVision;

    private NavMeshAgent agent =null;

    private Transform playerTransform = null;

    private Transform patrolDestination= null;

    private void Awake()
    {
        checkMyVision = GetComponent<CheckMyVision>();
        agent = GetComponent<NavMeshAgent>();
       // playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<CheckM>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] destinations = GameObject.FindGameObjectsWithTag("Dest");
        patrolDestination = destinations[Random.Range(0,destinations.Length)].GetComponent<Transform>();
        currentState = Enemy_State.PATROL;
        
    }

    public IEnumerator EnemyPatrol()
    {
        while(currentState==Enemy_State.PATROL)
        {
            checkMyVision.sensitivity = CheckMyVision.enmSensitivity.HIGH;

            agent.isStopped = false;
            agent.SetDestination(patrolDestination.position);

            while(agent.pathPending)
            {
                yield return null;
            }
            if(checkMyVision.targetInSight)
            {
                agent.isStopped =true;
                currentState = Enemy_State.CHASE;
                yield break;
            }
            yield break;
        }
        
    }

    public IEnumerator EnemyChase()
    {
        yield break;
    }
    public IEnumerator EnemyAttack()
    {
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
