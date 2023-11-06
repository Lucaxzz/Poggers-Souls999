using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    public Animator animator;
    private bool isPaused;

    [Header("Painéis e Menu")]
    public GameObject pausePanel;
    public string sceneToLoad;

    [SerializeField] private bool isKnockedBack = false;
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float knockbackForceUp = 5f; // Força vertical (pulo) no knockback
    [SerializeField] private float knockbackDuration = 0.2f;
    private Vector2 knockbackDirection;
    private float knockbackStartTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (!isKnockedBack)
        {
            float moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

            if (moveInput > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (moveInput < 0 && isFacingRight)
            {
                Flip();
            }

            animator.SetBool("taCorrendo", Mathf.Abs(moveInput) > 0);
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        pausePanel.SetActive(isPaused);
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void ApplyKnockback(Vector2 direction, float horizontalForce, float verticalForce)
    {
        isKnockedBack = true;
        knockbackDirection = direction.normalized;
        knockbackForce = horizontalForce;
        knockbackForceUp = verticalForce;
        knockbackStartTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (isKnockedBack)
        {
            float timeSinceKnockbackStarted = Time.time - knockbackStartTime;
            float knockbackProgress = timeSinceKnockbackStarted / knockbackDuration;

            Vector2 knockbackVelocity = new Vector2(
                knockbackDirection.x * knockbackForce,
                knockbackDirection.y * knockbackForceUp
            );

            if (knockbackProgress < 1f)
            {
                rb.velocity = Vector2.Lerp(Vector2.zero, knockbackVelocity, knockbackProgress);
            }
            else
            {
                isKnockedBack = false;
            }
        }
    }
}
