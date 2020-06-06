using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private string level;
    public void LoadTheLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
