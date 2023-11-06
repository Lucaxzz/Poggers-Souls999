using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaaMais : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

     public GameObject collected;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Recupere o componente HeartSystem do jogador
            HeartSystem playerHealth = other.GetComponent<HeartSystem>();

            if (playerHealth != null)
            {
                // Regenere a vida do jogador (adicione 1 à vida atual)
                playerHealth.vida++;
                // Destrua o coletável
                sr.enabled = false;
                circle.enabled = false;
                collected.SetActive(true);

                Destroy(gameObject, 1f);
            }
        }
    }
}
