using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{

    public AudioSource[] clips;
    private MoveThePlayer moveTheplayer;
    private bool isPlayerMoving;
    private bool isTurboOn;

    /*
        public enum CarState
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
                switch (currentState)
                {
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

        private void Awake()
        {

            //isPlayerMoving = GameObject.Find("Player").GetComponent<MoveThePlayer>().isMoving;
            //isTurboOn = GameObject.Find("Player").GetComponent<MoveThePlayer>().turbo;
        }
        // Start is called before the first frame update

        void Start()
        {
            moveTheplayer = GameObject.Find("Player").GetComponent<MoveThePlayer>();
            CurrentState = CarState.Stopped;
        }
        public IEnumerator CarStopped()
        {
            print("Stpped");
            while (currentState == CarState.Stopped)
            {

                if (!clips[0].isPlaying)
                {
                    clips[2].Stop();
                    clips[1].Stop();
                    clips[0].Play();
                }
                if (moveTheplayer.isMoving)
                {
                    print("Stop -> Moving");
                    CurrentState = CarState.Moving;

                    yield break;
                }

                yield return null;
            }

        }
        public IEnumerator CarMoving()
        {
            print("M<ovign");
            while (currentState == CarState.Moving)
            {
                if (!clips[1].isPlaying)
                {
                    clips[2].Stop();
                    clips[1].Play();
                    clips[0].Stop();

                    if (moveTheplayer.turbo)
                    {
                        print("Moving -> Turbo");
                        CurrentState = CarState.TurboMove;
                        yield break;

                    }
                   else if (!moveTheplayer.isMoving)
                    {
                        CurrentState = CarState.Stopped;
                        yield break;
                    }

                }

                yield return null;
            }
        }
        public IEnumerator TurboMove()
        {
            print("Turbo");
            while (currentState == CarState.TurboMove)
            {

                if (!clips[2].isPlaying)
                {
                    clips[2].Play();
                    clips[1].Stop();
                    clips[0].Stop();
                }
                if (moveTheplayer.isMoving && !moveTheplayer.turbo)
                {
                    print("Attack -> Chasing");
                    CurrentState = CarState.Moving;
                    yield break;
                }
                else if (!moveTheplayer.isMoving)
                {
                    // Do something

                    CurrentState = CarState.TurboMove;
                    yield break;
                }
                yield return null;
            }

            yield break;
        }
        */
    // Update is called once per frame
    void Start()
    {
        moveTheplayer = GameObject.Find("Player").GetComponent<MoveThePlayer>();
        
    }

    void Update()
    {
        isPlayerMoving = moveTheplayer.isMoving;
        isTurboOn =moveTheplayer.turbo;
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