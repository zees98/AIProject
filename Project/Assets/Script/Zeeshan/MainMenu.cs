using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject menuCam;
    
    public void PlayGame()
    {

        menuCam = GameObject.Find("Menu Cam");
      
        menuCam.transform.Rotate(new Vector3(0f, 122f, 0f));
        menuCam.transform.position = new Vector3(985f, 199.6f, -559.7f);
    }
    public void quit(){
        Application.Quit();
    }
}
