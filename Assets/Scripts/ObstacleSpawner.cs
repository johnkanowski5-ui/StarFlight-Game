using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1.45f;
    [SerializeField] private float obstacleSpeed = 4.5f;
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
            SpawnObstacle();
            timer = spawnInterval / (1f + Mathf.Clamp(GameManager.Instance.score / 100f, 0f, 3f));
        }
    }

    private void SpawnObstacle()
    {
        float height = Random.Range(1.6f, 4.2f);
        float y = Random.Range(-2.5f, 2.6f);

        GameObject obstacle = SimpleSpriteFactory.CreateSprite("Obstacle", new Color(1f, 0.2f, 0.5f), new Vector2(0.9f, height), new Vector3(10f, y, 0f));
        obstacle.tag = "Obstacle";
        obstacle.AddComponent<BoxCollider2D>();
        var rb = obstacle.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.left * (obstacleSpeed + GameManager.Instance.score * 0.02f);
        obstacle.layer = LayerMask.NameToLayer("Default");
        Destroy(obstacle, 6f);
    }
}
