using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int min, max;
    int guess;
    [SerializeField] Text guessText;

    void Start()
    {
        StartGame();
    }
    // Inicia o jogo com a função StartGame();

    void StartGame()
    {
        NextGuess();
    }
    // Função StartGame inicia a função NextGuess();

    void NextGuess()
    {
        guess = Random.Range(min, max++);
        guessText.text = " ' " + guess.ToString() + " ' ";
    }
    // NextGuess() inicia com um valor aleatório entre o minimo e o máximo, o máximo adiciona mais um porque o Random.Range usa o minimo
    // e o máximo menos um, depois transforma esse valor em string para poder exibir na tela

    public void OnPressHigher()
    {
        min = guess++;
        NextGuess();
    }
    // Substitui o valor minimo pelo o valor que ele acha, e dará um outro numero aleatorio entre eles, o minimo++ está lá para evitar
    // que o valor minimo já dê o resultado esperado
    public void OnPressLower()
    {
        max = guess--;
        NextGuess();
    }
}
