using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{

    public AudioSource[] clips;
    private bool isPlayerMoving =false;
    private bool isTurboOn = false;


   /* public enum CarState
    {
        Stopped,
        Moving,
        TurboMove,
    }
    [SerializeField]
    private CarState currentState;
    public CarState CurrentState
    {
        get { return currentState; }
        set
        {
            currentState = value;
            StopAllCoroutines();
            switch (currentState) {
                case CarState.Stopped:
                  StartCoroutine(CarStopped());
                    break;
                case CarState.Moving:
                  StartCoroutine(CarMoving());
                    break;
                case CarState.TurboMove:
                    StartCoroutine(TurboMove());
                    break;
            }
        }
    }
    public IEnumerator CarStopped() {
        print("Stopped");
       while (currentState == CarState.Stopped)
        {
            //Change Audio Source to Engine Sound
            if (!clips[0].isPlaying)
            {
                clips[2].Stop();
                clips[1].Stop();
                clips[0].Play();
            }
            if (isPlayerMoving)
            {
                CurrentState = CarState.Moving;
                yield break;
            }
            

            yield return null;
        }
    }
    public IEnumerator CarMoving() {
        print("Moving");
        while (currentState == CarState.Moving)
        {
            //Change Audio Source to Moving 
            if (!clips[1].isPlaying)
            {
                clips[2].Stop();
                clips[1].Play();
                clips[0].Stop();
            }
            if (isTurboOn)
                {
                    CurrentState = CarState.TurboMove;
                    yield break;
                }

            if(!isPlayerMoving)
            {
                CurrentState = CarState.Stopped;
                yield break;
           }
            yield return null;
        }
    }
    
    public IEnumerator TurboMove() {
        print("Turbo");
        //Change Audio Source to Turbo Sound
        while (currentState == CarState.TurboMove) {

            if (!clips[2].isPlaying)
            {
                clips[2].Play();
                clips[1].Stop();
                clips[0].Stop();
            }
            if (!isPlayerMoving)
            {
                CurrentState = CarState.Stopped;
                yield break;
            }
            else
            {
                if (!isTurboOn)
                {
                    CurrentState = CarState.Moving;
                    yield break;
                }
            }
            yield return null; 
        }
        
        
    }


    private void Awake()
    {
        isPlayerMoving = GameObject.Find("Player").GetComponent<MoveThePlayer>().isMoving;
        isTurboOn= GameObject.Find("Player").GetComponent<MoveThePlayer>().turbo;
    }
    // Start is called before the first frame update

    void Start()
    {
        CurrentState = CarState.Stopped;
    }
    */



    // Update is called once per frame
    
    void Update()
    {
        isPlayerMoving = GameObject.Find("Player").GetComponent<MoveThePlayer>().isMoving;
        isTurboOn = GameObject.Find("Player").GetComponent<MoveThePlayer>().turbo;
        if (isPlayerMoving)
        {
            if (isTurboOn)
            {
                clips[0].Stop();
                clips[1].Stop();
                if (!clips[2].isPlaying)
                {

                    clips[2].Play();
                }
            }
            else
            {
                clips[0].Stop();
                clips[2].Stop();
                if (!clips[1].isPlaying)
                {

                    clips[1].Play();
                }
            }
        }
        else
        {
            
            clips[1].Stop();
            clips[2].Stop();
            if (!clips[0].isPlaying)
            {

                
                clips[0].Play();
            }
        }

       
    }
    
}
