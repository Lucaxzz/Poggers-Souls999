using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public HeartSystem heart;
    public player1 player;

    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float knockbackForceUp = 5f; // Força vertical no knockback
    private bool canDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canDamage)
        {
            canDamage = false;
            heart.vida--;
            player.animator.SetTrigger("damage");

            Vector2 knockbackDirection = (player.transform.position - transform.position).normalized;

            // Aplique a força de knockback com impulso vertical
            player.ApplyKnockback(knockbackDirection, knockbackForce, knockbackForceUp);

            StartCoroutine(ResetCanDamage());
        }
    }

    IEnumerator ResetCanDamage()
    {
        yield return new WaitForSeconds(1.0f);
        canDamage = true;
    }
}
