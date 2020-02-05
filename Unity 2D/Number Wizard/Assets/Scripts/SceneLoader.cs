using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Controla as transições de cenas/fases do jogo

/* Para usar o SceneLoader é preciso que vá ao Unity -> File -> Build Settings e então colocar as cenas componentes do jogo,
   coloque na ordem que você deseja, pois ele vai criar um vetor que será utilizado nas funções abaixo.
 */
public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Dentro da classe SceneManager existe uma função/método chamada GetActiveScene() que vai retornar o valor cena ativa;
        SceneManager.LoadScene(currentSceneIndex + 1);
        // Dentro dessa função/método da classe SceneManager chamada LoadScene ela recebe um valor inteiro correspondente a fase ativa mais
        // um para ir para a próxima fase
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        // Essa função é usada para fechar a janela para sair do jogo;
    }
}
