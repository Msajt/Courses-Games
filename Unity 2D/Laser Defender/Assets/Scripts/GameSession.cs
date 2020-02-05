using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;

    private void Awake()
    {
        GameSessionSingleton();
    }

    private void GameSessionSingleton()
    {
        var gameSessionObjects = FindObjectsOfType(GetType()).Length;
        if (gameSessionObjects > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
