using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteDoInimigo : MonoBehaviour
{
    private Renderer rend;
    private int vidaAtual = 100;
    private bool atingido = false;
    private Color corOriginal;
    public Color corDano = Color.red; // Cor para indicar dano
    public GameObject explosaoPrefab; // Prefab da animação de explosão
    public Transform prefabSpawnPoint; // Ponto onde o prefab será instanciado

    private void Start()
    {
        rend = GetComponent<Renderer>();
        corOriginal = rend.material.color;
    }

    private void Update()
    {
        if (vidaAtual <= 0)
        {
            // Reproduza a animação de explosão (se houver)
            if (explosaoPrefab != null)
            {
                Instantiate(explosaoPrefab, prefabSpawnPoint.position, Quaternion.identity);
            }

            // Destrua o inimigo
            Destroy(gameObject);
        }
    }

    public void DanoNoInimigo()
    {
        if (!atingido)
        {
            vidaAtual -= 50; // Reduza a vida como desejar
            atingido = true;

            // Mude a cor para indicar dano
            rend.material.color = corDano;

            if (vidaAtual <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                // Restaure a cor original após um curto período
                StartCoroutine(RestaurarCorOriginal());
            }
        }
    }

    IEnumerator RestaurarCorOriginal()
    {
        yield return new WaitForSeconds(0.5f); // Ajuste o tempo conforme necessário
        atingido = false;
        rend.material.color = corOriginal;
    }
}
