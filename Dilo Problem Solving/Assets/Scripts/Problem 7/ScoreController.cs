using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text scoreText;

    private int score;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void addScore()
    {
        score += 1;
    }

    public void resetScore()
    {
        score = 0;
    }
}
