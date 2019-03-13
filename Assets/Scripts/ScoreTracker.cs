using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public Text scoreText;
   
    int score;

    private void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void AddPoint(int pointAmount)
    {
        score += pointAmount;
        scoreText.text = "Score: " + score;
    }
    
    
}
