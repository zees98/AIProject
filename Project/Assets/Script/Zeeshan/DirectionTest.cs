using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTest : MonoBehaviour {
    public GameObject otherObject;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        Debug.DrawRay (transform.position, otherObject.transform.position * 0.250f, Color.yellow);
    }
}