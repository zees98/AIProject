using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PositionTracking : MonoBehaviour
{
    public int position;
    public Transform AI, player;
    private Text positionText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // distance = player.position.normalized.magnitude - AI.position.normalized.magnitude;
        // print(distance);
       var  distance  = AI.position - player.position;
        var dProduct = Vector3.Dot(distance, AI.forward);
        if (dProduct > 0)
        {
            position = 2;
        }
        else if (dProduct < 0)
        {
            position = 1;
        }
       
    }
}
