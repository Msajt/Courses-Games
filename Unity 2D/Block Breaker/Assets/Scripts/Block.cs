using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config Parameters
    [SerializeField] AudioClip breakSound; // Variavel para colocar arquivos de audio
    [SerializeField] GameObject blockSparklesVFX; // GameObject referente ao sprite de particulas
    [SerializeField] Sprite[] hitSprites; // Vetor de sprites para blocos que mudam de acordo com as vezes que foi atingido

    // Cached Reference
    Level level; // Variavel usada para depositar FindObject do tipo Level

    // State Variables
    [SerializeField] int timesHit; // Contar quantas vezes o bloco foi atingido

    // O script inicializa com a função que contam apenas os blocos com tag de quebraveis
    private void Start()
    {
        CountBreakableBlocks();
    }

    // Função para contar os blocos quebraveis usando a função da classe Level depositada na variavel 'level'
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>(); // Caso eu não queira fazer um serialized field
        if (tag == "Breakable") level.CountBlocks();
    }

    // Quando ocorre alguma colisão no bloco liga essa função
    private void OnCollisionEnter2D(Collision2D collision)
    // Quando houver uma colisão em 2D, o parametro de entrada da função é o objeto que colidiu
    // Edit -> Snap Settings
    {
        if (tag == "Breakable") // Verifica se é quebravel
        {
            timesHit++; // Aumenta quantas vezes foi atingido
            int maxHits = hitSprites.Length + 1; // variavel contabilizar o life do bloco de acordo com tamanho do vetor hitSprites
            if (timesHit == maxHits) DestroyBlock(); // se forem o mesmo valor, o bloco é destruido senao passa pro proximo sprite
            else ShowNextHitSprite();
        }
    }

    // Função para trocar o vetor quando o bloco é atingido
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else Debug.Log("Block sprite is missing from array." + gameObject.name);
    }

    // Função que liga quando o bloco é destruido
    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position); // Liga o som
        FindObjectOfType<GameStatus>().AddToScore(); // Usa a função do GameStatus para ser usada pra aumentar a pontuação
        level.DecreaseBreakedBlocks(); // Usa a função do Level para diminuir a quantidade de blocos
        TriggerSparklesVFX(); // Liga a particula
        Destroy(gameObject); // Remove o bloco
    }

    // Função que aciona as particulas
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation); // cria uma variavel para depositar e acionar a particula na posição do bloco 
        Destroy(sparkles, 2f); // Destroi a particula deoois de 2 segundos
    }
}
