using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    GameSession gameSession;
    Text scoreText;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
