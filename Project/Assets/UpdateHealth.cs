using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour {
    // Start is called before the first frame update
    private Health player;
    void Start () {
        player = GameObject.Find ("Player").GetComponent<Health> ();
    }

    // Update is called once per frame
    void Update () {
        GetComponent<Text> ().text = "Health " + player.health * 1;
    }
}