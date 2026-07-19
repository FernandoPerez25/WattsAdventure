using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;

    void Start()
    {
        victoryPanel.SetActive(false);
    }

    public void ShowVictory()
    {
        victoryPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!victoryPanel.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;

            SceneManager.LoadScene("Level1");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1f;

            SceneManager.LoadScene("MainMenu");
        }
    }
}