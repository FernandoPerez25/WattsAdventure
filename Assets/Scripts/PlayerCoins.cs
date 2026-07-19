using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private PlayerHealth playerHealth;

    private int coins = 0;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        // Prueba temporal
        if (Input.GetKeyDown(KeyCode.C))
        {
            AddCoin(1);
        }
    }

    public void AddCoin(int amount)
    {
        coins += amount;

        CheckExtraLife();

        UpdateUI();
    }

    private void CheckExtraLife()
    {
        while (coins >= 100)
        {
            coins -= 100;

            playerHealth.Heal(1);
        }
    }

    private void UpdateUI()
    {
        coinText.text = "x" + coins.ToString("000");
    }
}