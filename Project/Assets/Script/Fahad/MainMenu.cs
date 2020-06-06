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
        menuCam.transform.position = new Vector3(1228.7f, 205.5f, -794.7f);
        menuCam.transform.Rotate(new Vector3(0f, 90f, 0f));
    }
    public void quit(){
        Application.Quit();
    }
}
