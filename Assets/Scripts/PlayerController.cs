using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float flapForce = 6f;
    [SerializeField] private float gravity = 18f;
    [SerializeField] private float maxY = 4.5f;
    [SerializeField] private float minY = -4.5f;

    private Rigidbody2D rb;
    private int shieldHits;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        if (!GameManager.Instance || !GameManager.Instance.isPlaying)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            DoFlap();
        }

        var pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance || !GameManager.Instance.isPlaying)
        {
            return;
        }

        rb.velocity += Vector2.down * gravity * Time.fixedDeltaTime;
    }

    public void DoFlap()
    {
        rb.velocity = Vector2.up * flapForce;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            UpgradeManager.Instance.AddCoins(1);
            GameManager.Instance.AddScore(10f);
            return;
        }

        if (other.CompareTag("Obstacle"))
        {
            if (UpgradeManager.Instance.GetShieldLevel() > shieldHits)
            {
                shieldHits++;
                Destroy(other.gameObject);
                return;
            }

            GameManager.Instance.EndGame();
        }
    }
}
