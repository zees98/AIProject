using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour {
    // Start is called before the first frame update
    private Slider healthSlider;
    private HealthCode player;

    void Start () {

        healthSlider = GameObject.Find ("Slider").GetComponent<Slider> ();
        player = GameObject.Find("Player").GetComponent<HealthCode>();
    }

    // Update is called once per frame
    void Update () {
        
        healthSlider.value = player.health / 100;
    }
}