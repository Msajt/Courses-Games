using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // Serialize for debug purposes
    SceneLoader sceneLoader; // Cria uma variavel do tipo Scene que vai ser usada para nao precisar usar sempre FindObject

    // Informações em cache devem ser sempre colocadas no Start
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Cada bloco colocado será contatdo mais um, essa função vai ser usada dentro do script Block.cs;
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    // Cada bloco destruido vai diminuir -1, se não tiver nenhum bloco mais, vai pra próxima fase, usada dentro do Block.cs
    public void DecreaseBreakedBlocks()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
