using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Text scoreText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text bestText;
    [SerializeField] private Text statusText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject hudPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        RefreshHUD();
        ShowInGameUI();
    }

    public void RefreshHUD()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(GameManager.Instance ? GameManager.Instance.score : 0f);
        }

        if (coinsText != null)
        {
            coinsText.text = "Coins: " + UpgradeManager.Instance.GetTotalCoins();
        }

        if (bestText != null)
        {
            bestText.text = "Best: " + Mathf.FloorToInt(GameManager.Instance ? GameManager.Instance.bestScore : 0f);
        }

        if (statusText != null)
        {
            statusText.text = "Tap to fly";
        }
    }

    public void ShowInGameUI()
    {
        if (hudPanel != null)
        {
            hudPanel.SetActive(true);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        RefreshHUD();
    }

    public void ShowGameOverUI()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (statusText != null)
        {
            statusText.text = "Game Over";
        }

        RefreshHUD();
    }

    public void StartButtonPressed()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartGame();
        }
    }

    public void RestartButtonPressed()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartGame();
        }
    }
}
