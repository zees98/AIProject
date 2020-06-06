using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Wins");
            Destroy(player.GetComponent<MoveThePlayer>());
            Destroy(gameObject);


        }
        else if (other.CompareTag("NPC"))
        {
            Debug.Log("NPC Wins");
        }

    }
}
