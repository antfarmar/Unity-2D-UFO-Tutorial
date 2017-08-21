using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Updates the ScoreText UI via UnityEvent messaging from the player script.
public class ScoreController : MonoBehaviour
{
    private Text scoreText;

    // Use this for initialization
    void Start()
    {
        scoreText = GetComponent<Text>();
        setScore(0);
    }

    // Invoked by the player when trigger-colliding with a pickup.
    public void updateScoreEvent(int score)
    {
        setScore(score);
    }

    void setScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
