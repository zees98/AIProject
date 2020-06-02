using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI__FSM : MonoBehaviour {

    // Enums to keep states
    public enum ENEMY_STATES { patrol, chase, attack }

    // We need a property to get the current state
    private ENEMY_STATES currentState;
    public ENEMY_STATES CurrentState {
        get { return currentState; }
        set {
            currentState = value;
            StopAllCoroutines ();
            switch (currentState) {
                case ENEMY_STATES.patrol:
                    // StartCoRoutine (EnemyPatrol ());
                    break;
                case ENEMY_STATES.chase:
                    // StartCoRoutine (EnemyChase ());
                    break;
                case ENEMY_STATES.attack:
                    // StartCoRoutine (EnemyAttack ());
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
        playerTransform = GameObject.Find ("Player").GetComponent<Transform> ();
    }
    // Start is called before the first frame update
    void Start () {
        GameObject[] destinations = GameObject.FindGameObjectsWithTag ("Dest");

        patrolDestination = destinations[Random.Range (0, destinations.Length)].GetComponent<Transform> ();

        currentState = ENEMY_STATES.patrol;
    }

    public IEnumerator EnemyPatrol () {
        while (currentState == ENEMY_STATES.patrol) {
            checkMyVision.sensitivity = CheckMyVision.Sensitivity.HIGH;
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
        yield break;
    }
    public IEnumerator EnemyAttack () {
        yield break;
    }

    // Update is called once per frame
    void Update () {

    }
}