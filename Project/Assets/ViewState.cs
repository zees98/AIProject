using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewState : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy_FSM state ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        state = GameObject.Find("AI").GetComponent<Enemy_FSM>();
        GetComponent<Text>().text = "State " + state.CurrentState + "";
    }
}
