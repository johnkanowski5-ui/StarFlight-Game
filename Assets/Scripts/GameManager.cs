using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float score;
    public float bestScore;
    public bool isPlaying;

    public event Action<float> ScoreChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        bestScore = PlayerPrefs.GetFloat("StarFlightBestScore", 0f);
    }

    public void StartGame()
    {
        score = 0f;
        isPlaying = true;
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowInGameUI();
        }
    }

    public void EndGame()
    {
        if (!isPlaying)
        {
            return;
        }

        isPlaying = false;
        bestScore = Mathf.Max(bestScore, score);
        PlayerPrefs.SetFloat("StarFlightBestScore", bestScore);

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowGameOverUI();
        }
    }

    public void AddScore(float amount)
    {
        if (!isPlaying)
        {
            return;
        }

        score += amount;
        ScoreChanged?.Invoke(score);
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("StarFlightBestScore", bestScore);
        }
    }
}
