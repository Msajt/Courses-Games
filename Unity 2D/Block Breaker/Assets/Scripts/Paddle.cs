using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f; // Tamanho da tela
    [SerializeField] float minX = 2f, maxX = 14f; // Clamp pra limitar a posição

    void Update()
    {
        float mousePosInUnit = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        // Posição do mouse / tamanho da tela * tamanho da camera
        Vector2 paddlePos = new Vector2(mousePosInUnit, transform.position.y); // muda a posição de acordo com o movimento do mouse
        paddlePos.x = Mathf.Clamp(mousePosInUnit, minX, maxX);
        transform.position = paddlePos;
    }
}
