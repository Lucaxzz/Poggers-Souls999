using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollow : MonoBehaviour
{
    public Transform target; // Referência ao transform do jogador que o pet deve seguir.
    public float followSpeed = 3.0f; // Velocidade de seguimento do pet.
    public float followDistance = 2.0f; // Distância para começar a seguir o jogador.
    private bool isFollowing = false; // Variável para controlar se o pet está seguindo.
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale; // Salva a escala inicial do pet.
    }

    private void Update()
    {
        if (target != null)
        {
            // Calcule a direção do pet para o jogador.
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 moveDirection = targetPosition - transform.position;

            // Verifique se o jogador está dentro da distância especificada para começar a seguir.
            if (moveDirection.magnitude <= followDistance)
            {
                isFollowing = true;
            }

            // Se estiver seguindo, normalize a direção e aplique a velocidade de seguimento.
            if (isFollowing)
            {
                moveDirection.Normalize();
                transform.position += moveDirection * followSpeed * Time.deltaTime;

                // Inverta a escala horizontal do pet com base na direção do jogador.
                if (moveDirection.x > 0)
                {
                    transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
                }
                else if (moveDirection.x < 0)
                {
                    transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
                }
            }
        }
    }
}
