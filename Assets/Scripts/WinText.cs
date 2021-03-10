using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    public void SetResults(int playerLives, int score) 
    {
        livesText.text = "remaining lives: " + playerLives;
        scoreText.text = "Total Score: " + score;
    }
}
