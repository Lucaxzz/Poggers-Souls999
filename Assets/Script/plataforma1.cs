using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma1 : MonoBehaviour
{
    public float speed = 3f;  // Velocidade do inimigo
    public float patrolDistance = 5f;  // Distância máxima para patrulhar
    private bool movingRight = true;  // Inicialmente, o inimigo se move para a direita

    private Vector3 initialPosition;
    private Vector3 scale;

    void Start()
    {
        initialPosition = transform.position;  // Salvar a posição inicial
        scale = transform.localScale; // Salvar a escala inicial
    }

    void Update()
    {
        // Mova o inimigo
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        // Verifique se o inimigo alcançou a distância máxima
        if (Vector3.Distance(initialPosition, transform.position) >= patrolDistance)
        {
            // Inverta a direção
            movingRight = !movingRight;

            // Inverta a escala (para inverter a direção visualmente)
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
