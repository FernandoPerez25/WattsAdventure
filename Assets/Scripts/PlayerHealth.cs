using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float invulnerabilityTime = 1f;
    [SerializeField] private float knockbackForce = 6f;
    [SerializeField] private float knockbackHeight = 3f;
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private float deathY = -7.50f;

    private bool isDead = false;

    private Rigidbody2D rb;

    private bool isInvulnerable = false;

    private SpriteRenderer spriteRenderer;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Vector2 enemyPosition)
    {
        if (isInvulnerable)
            return;

        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        Vector2 knockbackDirection =
        (transform.position.x > enemyPosition.x)
        ? Vector2.right
        : Vector2.left;

        rb.velocity = new Vector2(
            knockbackDirection.x * knockbackForce,
            knockbackHeight
        );

        Debug.Log("Vida actual: " + currentHealth);

        if (currentHealth == 0)
        {
            gameOverManager.ShowGameOver();
        }

        StartCoroutine(Invulnerability());
    }

    private IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        float elapsed = 0f;

        while (elapsed < invulnerabilityTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;

            yield return new WaitForSeconds(0.1f);

            elapsed += 0.1f;
        }

        spriteRenderer.enabled = true;

        isInvulnerable = false;
    }

    void Update()
    {
        if (transform.position.y < deathY && !isDead)
        {
            isDead = true;
            gameOverManager.ShowGameOver();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Vida actual: " + currentHealth);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}