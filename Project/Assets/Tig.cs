using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tig : MonoBehaviour
{
       private float points = 0f;
      private GameObject coin;
      Text score1;
    // Start is called before the first frame update
    void Start()
    {
          coin = GameObject.FindGameObjectWithTag("coin");
          score1 = GameObject.Find("E").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other)
    {
       
      if (other.gameObject.CompareTag("coin"))
        {
            points +=1;
            Destroy(other.gameObject);
           
            score1.text = "Player 2: "+points.ToString("0");
        }

    }
}
