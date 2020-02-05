using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Controla as transições de cenas/fases do jogo

/* Para usar o SceneLoader é preciso que vá ao Unity -> File -> Build Settings e então colocar as cenas componentes do jogo,
   coloque na ordem que você deseja, pois ele vai criar um vetor que será utilizado nas funções abaixo.
 */
public class SceneLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game Scene");
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());    
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
