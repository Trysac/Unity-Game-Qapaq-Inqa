using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void StartFirstLevel()
    {
        SceneManager.LoadScene(2);
        try 
        { 
            FindObjectOfType<GameSession>().DestroyGameSession();
        }
        catch { Debug.Log("Estabas en el menu principal"); }
        
        FindObjectOfType<Music>().DestroyMusic();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().DestroyGameSession();
        FindObjectOfType<Music>().DestroyMusic();
    }

    public void QuitAplication() 
    {
        Application.Quit();
    }
}
