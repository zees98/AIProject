using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Won : MonoBehaviour
{
    private GameObject player;
    private Text gameover;
    void Start()
    {
        player = GameObject.Find("Player");
        gameover = GameObject.Find("Title").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        //If Player collides with the finishline empty object then the game ends and Movement controls are deleted
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Wins");
            Destroy(player.GetComponent<MovePlayer>());
            
            Destroy(gameObject);
            gameover.text = "Winner\n" +
                "Player 1";

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Wins");
            Destroy(player.GetComponent<MovePlayer>());
            Destroy(gameObject);
            gameover.text = "Winner\n" +
                "Player 1";
        }

    }
}