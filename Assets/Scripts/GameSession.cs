using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    int playerLives = 3;
    int score = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    [SerializeField] Text countArtifatsText;
    [SerializeField] Text artifatsText;
    [SerializeField] Image heart;
    [SerializeField] Image artifact;


    int artifatsCount = 0;
    int activeScene;


    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start () 
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;

        if (activeScene != 6 && activeScene != 7) 
        {
            countArtifatsText.text = artifatsCount.ToString();
            livesText.text = playerLives.ToString();
            scoreText.text = score.ToString();
        }
	}

    public void AddToScore (int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            GameOver();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    private void GameOver()
    {
        SceneManager.LoadScene(7);
        //Destroy(gameObject);
    }

    public void SetArtifactCount() 
    {
        artifatsCount = FindObjectsOfType<Artifact>().Length;
        countArtifatsText.text = artifatsCount.ToString();
    }

    private void Update()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1) 
        {
            Destroy(gameObject);
        }
        else if (currentSceneIndex == 6 || currentSceneIndex == 7) 
        {
            heart.enabled = false;
            artifact.enabled = false;
            countArtifatsText.enabled = false;
            artifatsText.enabled = false;
            livesText.enabled = false;
            scoreText.enabled = false;

            if (currentSceneIndex == 6)
            {
                FindObjectOfType<WinText>().SetResults(playerLives,score);
            }
            else
            {
                FindObjectOfType<GameOverText>().SetResults(score);
            }
        }
        else 
        {
            SetArtifactCount();
        }
    }

    public void AddLives() 
    {
        playerLives++;
        if(livesText != null)
            livesText.text = playerLives.ToString();
    }

    public void DestroyGameSession() 
    {
        Destroy(gameObject);
    }
}
