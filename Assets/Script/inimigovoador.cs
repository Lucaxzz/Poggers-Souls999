using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigovoador : MonoBehaviour
{
    public float speed = 3f;  // Velocidade do elevador
    public float verticalDistance = 5f;  // Distância máxima para subir e descer
    private bool movingUp = true;  // Inicialmente, o elevador se move para cima

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;  // Salvar a posição inicial
    }

    void Update()
    {
        // Mova o elevador
        if (movingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        // Verifique se o elevador alcançou a distância máxima
        if (Vector3.Distance(initialPosition, transform.position) >= verticalDistance)
        {
            // Inverta a direção
            movingUp = !movingUp;
        }
    }
}