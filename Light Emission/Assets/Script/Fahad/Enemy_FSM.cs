using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_FSM : MonoBehaviour
{
     
     public enum ENEMY_STATES { patrol, chase, attack };
    [SerializeField]
    private ENEMY_STATES currentState;
    private Health playerhealth = null;
    public float maxDamage = 10f;
    public ENEMY_STATES CurrentState {
        get { return currentState; }
        set {
            currentState = value;
            StopAllCoroutines ();
            switch (currentState) {
                case ENEMY_STATES.patrol:
                    StartCoroutine(EnemyPatrol());
                    break;
                case ENEMY_STATES.chase:
                    StartCoroutine(EnemyChase());
                    break;
                case ENEMY_STATES.attack:
                    StartCoroutine(EnemyAttack());
                    break;
            }
        }
    }

    private CheckMyVision checkMyVision;
    private NavMeshAgent agent = null;
    private Transform playerTransform = null;

    private Transform patrolDestination = null;

    private void Awake () {
        checkMyVision = GetComponent<CheckMyVision> ();
        agent = GetComponent<NavMeshAgent> ();
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> ();
    }
    // Start is called before the first frame update
    void Start () {
        GameObject[] destinations = GameObject.FindGameObjectsWithTag("Dest");

        patrolDestination = destinations[Random.Range (0, destinations.Length)].GetComponent<Transform> ();

        currentState = ENEMY_STATES.patrol;
    }

    public IEnumerator EnemyPatrol () {
        while (currentState == ENEMY_STATES.patrol) {
            checkMyVision.sensitivity = CheckMyVision.enmSensitivity.HIGH;
            agent.isStopped = false;
            agent.SetDestination (patrolDestination.position);
            while (agent.pathPending)
                yield return null;
            if (checkMyVision.targetInSight) {
                agent.isStopped = true;
                currentState = ENEMY_STATES.chase;
                yield break;
            }

        }
        yield break;
    }
    public IEnumerator EnemyChase () {
         while(currentState ==ENEMY_STATES.chase)
        {
            //In this case, let us keep sensitivity low
            checkMyVision.sensitivity = CheckMyVision.enmSensitivity.LOW;
            //The idea of the chase is to go to the last know position
            agent.isStopped = false;
            agent.SetDestination(checkMyVision.lastKnowSighting);
            //again we need to yield if path is yet incomplete
            while(agent.pathPending){
                yield return null;
            }
            //while chasing we need to keep checking if we reached
            if(agent.remainingDistance <=agent.stoppingDistance)
            {
                agent.isStopped = true;
                //what if reached destination but cannot see the player
                if(!checkMyVision.targetInSight)
                    currentState = ENEMY_STATES.patrol;
                else
                    currentState = ENEMY_STATES.attack;
                yield break;
            }
            //Till next frame
            yield return null;

        }
        yield break;
    }
    public IEnumerator EnemyAttack () {
       while(currentState ==ENEMY_STATES.attack)
        {
            //The idea of the attack is to go to the last know position
            agent.isStopped = false;
            agent.SetDestination(playerTransform.position);
            //again we need to yield if path is yet incomplete
            while(agent.pathPending){
                yield return null;
            }
            //while chasing we need to keep checking if we reached
            if(agent.remainingDistance > agent.stoppingDistance)
            {
                currentState =ENEMY_STATES.chase;
            }
            else
            {
                playerhealth.healthpoints-=maxDamage*Time.deltaTime;

            }   
            
            //Till next frame
            yield return null;

        }
        yield break;
    }

    // Update is called once per frame
    void Update () {

    }
}
  