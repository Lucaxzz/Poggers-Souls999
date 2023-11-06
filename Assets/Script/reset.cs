using UnityEngine;
using UnityEditor;

public class reset : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifique se o objeto que tocou no Collider2D tem uma tag específica
        if (other.CompareTag("Player"))
        {
#if UNITY_EDITOR
            // Saia do editor Unity (apenas durante a edição)
            EditorApplication.ExitPlaymode();
#endif
        }
    }
}