using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    [SerializeField] Text scoreText;


    public void SetResults(int score)
    {
        scoreText.text = "Total Score: " + score;
    }
}
