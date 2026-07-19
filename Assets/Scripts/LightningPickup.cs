using UnityEngine;

public class LightningPickup : MonoBehaviour
{
    [SerializeField] private int coinAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Algo tocó el rayo: " + other.name);

        PlayerCoins playerCoins = other.GetComponent<PlayerCoins>();

        if (playerCoins != null)
        {
            playerCoins.AddCoin(coinAmount);

            Destroy(gameObject);
        }
    }
}