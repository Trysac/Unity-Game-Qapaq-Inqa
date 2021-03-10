using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMoFactor = 0.2f;

    bool nextLevel = false;
    int currentLevel;

    private void Start()
    {
        nextLevel = false;
        currentLevel = SceneManager.GetActiveScene().buildIndex;         
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") 
        {
            if (SceneManager.GetActiveScene().buildIndex != 1 ) 
            { 
                int artifactCound = FindObjectsOfType<Artifact>().Length;
                if (artifactCound == 0)
                {
                    if (nextLevel == false && currentLevel != 5) 
                    {
                        nextLevel = true;
                        FindObjectOfType<GameSession>().AddLives();
                    }    
                    StartCoroutine(LoadNextLevel());
                }
            }
            else 
            {
                StartCoroutine(LoadNextLevel());
            }          
        }   
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;  
        SceneManager.LoadScene(currentLevel + 1);
    }

}
