using UnityEngine;

public class GoalFinish : MonoBehaviour
{
    [SerializeField] private VictoryManager victoryManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            victoryManager.ShowVictory();
        }
    }
}