using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootstrap : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void SetupGame()
    {
        if (FindObjectOfType<GameManager>() == null)
        {
            var gameManagerObject = new GameObject("GameManager");
            gameManagerObject.AddComponent<GameManager>();
        }

        if (FindObjectOfType<UpgradeManager>() == null)
        {
            var upgradeManagerObject = new GameObject("UpgradeManager");
            upgradeManagerObject.AddComponent<UpgradeManager>();
        }

        if (FindObjectOfType<PlayerController>() == null)
        {
            var player = SimpleSpriteFactory.CreateSprite("Player", Color.yellow, new Vector2(0.8f, 0.8f), new Vector3(-6f, 0f, 0f));
            player.tag = "Player";
            player.AddComponent<Rigidbody2D>();
            player.GetComponent<Rigidbody2D>().gravityScale = 0f;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            player.AddComponent<CircleCollider2D>();
            player.AddComponent<PlayerController>();
        }

        if (FindObjectOfType<ObstacleSpawner>() == null)
        {
            var spawner = new GameObject("ObstacleSpawner");
            spawner.AddComponent<ObstacleSpawner>();
        }

        if (FindObjectOfType<CoinSpawner>() == null)
        {
            var coinSpawner = new GameObject("CoinSpawner");
            coinSpawner.AddComponent<CoinSpawner>();
        }

        if (FindObjectOfType<UIManager>() == null)
        {
            CreateUI();
        }

        Camera.main.backgroundColor = new Color(0.04f, 0.04f, 0.12f);
        Camera.main.orthographicSize = 6f;
    }

    private static void CreateUI()
    {
        var canvasObject = new GameObject("Canvas");
        var canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObject.AddComponent<CanvasScaler>();
        canvasObject.AddComponent<GraphicRaycaster>();

        var hud = new GameObject("HUD");
        hud.transform.SetParent(canvasObject.transform, false);
        var hudImage = hud.AddComponent<Image>();
        hudImage.color = new Color(0f, 0f, 0f, 0f);

        var scoreText = new GameObject("ScoreText");
        scoreText.transform.SetParent(hud.transform, false);
        var score = scoreText.AddComponent<Text>();
        score.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        score.text = "Score: 0";
        score.fontSize = 28;
        score.color = Color.white;
        var scoreRect = scoreText.GetComponent<RectTransform>();
        scoreRect.anchorMin = new Vector2(0f, 1f);
        scoreRect.anchorMax = new Vector2(0f, 1f);
        scoreRect.pivot = new Vector2(0f, 1f);
        scoreRect.anchoredPosition = new Vector2(20f, -30f);
        scoreRect.sizeDelta = new Vector2(200f, 40f);

        var coinsText = new GameObject("CoinsText");
        coinsText.transform.SetParent(hud.transform, false);
        var coins = coinsText.AddComponent<Text>();
        coins.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        coins.text = "Coins: 0";
        coins.fontSize = 28;
        coins.color = Color.yellow;
        var coinsRect = coinsText.GetComponent<RectTransform>();
        coinsRect.anchorMin = new Vector2(1f, 1f);
        coinsRect.anchorMax = new Vector2(1f, 1f);
        coinsRect.pivot = new Vector2(1f, 1f);
        coinsRect.anchoredPosition = new Vector2(-20f, -30f);
        coinsRect.sizeDelta = new Vector2(200f, 40f);

        var bestText = new GameObject("BestText");
        bestText.transform.SetParent(hud.transform, false);
        var best = bestText.AddComponent<Text>();
        best.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        best.text = "Best: 0";
        best.fontSize = 22;
        best.color = Color.white;
        var bestRect = bestText.GetComponent<RectTransform>();
        bestRect.anchorMin = new Vector2(0.5f, 1f);
        bestRect.anchorMax = new Vector2(0.5f, 1f);
        bestRect.pivot = new Vector2(0.5f, 1f);
        bestRect.anchoredPosition = new Vector2(0f, -35f);
        bestRect.sizeDelta = new Vector2(200f, 40f);

        var statusText = new GameObject("StatusText");
        statusText.transform.SetParent(hud.transform, false);
        var status = statusText.AddComponent<Text>();
        status.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        status.text = "Tap to start";
        status.fontSize = 42;
        status.color = Color.white;
        status.alignment = TextAnchor.MiddleCenter;
        var statusRect = statusText.GetComponent<RectTransform>();
        statusRect.anchorMin = new Vector2(0.5f, 0.5f);
        statusRect.anchorMax = new Vector2(0.5f, 0.5f);
        statusRect.pivot = new Vector2(0.5f, 0.5f);
        statusRect.sizeDelta = new Vector2(400f, 80f);

        var uiManager = canvasObject.AddComponent<UIManager>();
        uiManager.SetReferences(score, coins, best, status);
    }
}
