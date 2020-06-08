using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLineLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Text winText;
    void Start()
    {
        player = GameObject.Find("Player");
        winText = GameObject.Find("Win Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        //If Player collides with the finishline empty object then the game ends and Movement controls are deleted
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Wins");
            Destroy(player.GetComponent<MoveThePlayer>());
            Destroy(GameObject.Find("Car Sounds"));
            Destroy(gameObject);
            winText.text = "Winner\n" +
                "Player 1";

        }
        else if (other.CompareTag("NPC"))
        {
            Debug.Log("NPC Wins");
            Destroy(player.GetComponent<MoveThePlayer>());
            Destroy(GameObject.Find("Car Sounds"));
            Destroy(gameObject);
            winText.text = "Winner\n" +
                "NPC";
        }

    }
}
