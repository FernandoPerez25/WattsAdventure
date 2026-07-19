using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image[] lifeIcons;

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();

        if (playerHealth == null)
        {
            Debug.LogError("No se encontró PlayerHealth en la escena.");
        }

        UpdateHealthUI();
    }

    void Update()
    {
        if (playerHealth == null)
            return;

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        int currentHealth = playerHealth.GetCurrentHealth();

        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = i < currentHealth;
        }
    }
}