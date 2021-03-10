using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadMainMenu", 4f);
    }

    private void LoadMainMenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
