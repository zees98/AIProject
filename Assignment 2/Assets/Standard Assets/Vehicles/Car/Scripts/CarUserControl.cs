using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car {
    [RequireComponent (typeof (CarController))]
    public class CarUserControl : MonoBehaviour {
        private CarController m_Car; // the car controller we want to use
        private Rigidbody carRB;
        public float gravityMod = 1.0f;
        public float speedMod = 150.0f;

        private void Awake () {
            // get the car controller
            m_Car = GetComponent<CarController> ();
            carRB = GetComponent<Rigidbody> ();
            Physics.gravity *= gravityMod;
        }

        private void FixedUpdate () {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis ("Horizontal");
            float v = CrossPlatformInputManager.GetAxis ("Vertical");

            float handbrake = CrossPlatformInputManager.GetAxis ("Jump");
            m_Car.Move (h, v, v, handbrake);
            carRB.AddForce(Vector3.back * speedMod * v ,ForceMode.Force);

        }
    }
}