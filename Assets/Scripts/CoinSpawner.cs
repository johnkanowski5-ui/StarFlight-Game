using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float coinInterval = 1.1f;
    [SerializeField] private float coinSpeed = 4.2f;
    private float timer;

    private void Update()
    {
        if (!GameManager.Instance || !GameManager.Instance.isPlaying)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnCoin();
            timer = coinInterval / (1f + Mathf.Clamp(GameManager.Instance.score / 120f, 0f, 2.5f));
        }
    }

    private void SpawnCoin()
    {
        float y = Random.Range(-3f, 3f);
        GameObject coin = SimpleSpriteFactory.CreateSprite("Coin", new Color(1f, 1f, 0.25f), new Vector2(0.5f, 0.5f), new Vector3(10f, y, 0f));
        coin.tag = "Coin";
        coin.AddComponent<CircleCollider2D>();
        var rb = coin.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.left * (coinSpeed + GameManager.Instance.score * 0.02f);
        Destroy(coin, 6f);
    }
}
