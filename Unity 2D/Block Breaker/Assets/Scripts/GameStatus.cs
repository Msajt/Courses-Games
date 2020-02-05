using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [Range(0f, 10f)][SerializeField] float gameSpeed = 1f; // Cria uma barra capaz de mudar a velocidade do jogo
    [SerializeField] int pointsPerBlockDestroyed = 83; // Valor de pontos a cada bloco quebrado
    [SerializeField] int currentScore = 0; // Pontuação exibida
    [SerializeField] Text scoreText; // Texto da pontuação

    // Antes de entrar no Start(), o jogo verifica se já há uma exibição do HUD de pontuação;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Inicia a pontuação em 0 no Start()
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Time.timeScale muda a velocidade do tempo, e no update posso ficar mudando usando a variavel gameSpeed que vai de 0 a 10
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    // Toda vez que eu destruo um bloco irá adicionar mais pontuação, essa função vai ser usada no script Block.cs
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    // Toda vez que o jogo reseta deleta a HUD de pontuação para poder criar outra
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
