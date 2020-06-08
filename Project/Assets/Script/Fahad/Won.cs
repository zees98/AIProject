using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Won : MonoBehaviour
{
    [SerializeField]private string level;
    // Start is called before the first frame update
    void Start()
    {
      
     
    
        
    }
       private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        Debug.Log("YOU WON");
        else  if(other.CompareTag("Enemy"))
        Debug.Log("YOU Lost");
        
    
    }

    // Update is called once per frame
    void Update()
    {
      
       
    }
}
