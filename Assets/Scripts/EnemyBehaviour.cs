using UnityEngine;
using TMPro;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Settings")]
    public int speed = 5;
    public int life = 3;
    public int scoreToAdd = 10;

    [Header("Components")]
    private Rigidbody2D enemyRb;
    private AudioSource enemyAudioSource;

    [Header("References")]
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private GameObject enemyExplosion;
    [SerializeField] private GameObject playerBulletHitVFX;
    [SerializeField] private AudioClip getHitSFX;

    private EnemySpawner enemySpawner;
    private KillCountDownerUI killCountDownerUI;

    [Header("Shooting")]
    private float enemyFireRate = 2f;

    void Start()
    {
        InitializeComponents();
    }

    void FixedUpdate()
    {
        MoveEnemy();
        HandleEnemyShooting();
    }

    private void InitializeComponents()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAudioSource = GetComponent<AudioSource>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        killCountDownerUI = FindObjectOfType<KillCountDownerUI>();
    }

    private void MoveEnemy()
    {
        enemyRb.velocity = Vector2.left * speed;
    }

    private void HandleEnemyShooting()
    {
        if (gameObject.CompareTag("Enemy 1") && transform.position.x < 8)
        {
            transform.position = new Vector3(8, transform.position.y, transform.position.z);
            ShootEnemyBullet();
        }
    }

    private void ShootEnemyBullet()
    {
        enemyFireRate -= Time.deltaTime;
        if (enemyFireRate <= 0)
        {
            Vector3 bulletSpawnPos = new Vector3(5, transform.position.y, 0);
            Instantiate(enemyBullet, bulletSpawnPos, enemyBullet.transform.rotation);
            enemyFireRate = 2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            HandlePlayerBulletHit(other);
        }
        else if (other.CompareTag("PlayerUlt"))
        {
            HandlePlayerUltimateHit();
        }
    }

    private void HandlePlayerBulletHit(Collider2D other)
    {
        Instantiate(playerBulletHitVFX, other.transform.position, Quaternion.identity);
        PlayAudio(getHitSFX);
        Destroy(other.gameObject);

        life--;
        FindObjectOfType<UltimateBarUI>()?.AddUltimatePoints(7f);

        if (life <= 0)
        {
            HandleEnemyDeath();
        }
    }

    private void HandlePlayerUltimateHit()
    {
        HandleEnemyDeath();
    }

    private void HandleEnemyDeath()
    {
        Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        DestroyEnemy();
        UpdateKillCount();
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        if (enemySpawner != null)
        {
            //enemySpawner.AddScore(scoreToAdd); // Add score using the EnemySpawner's method
        }
    }

    private void UpdateKillCount()
    {
        if (killCountDownerUI != null)
        {
            killCountDownerUI.IncrementKillCount(gameObject.tag);
        }
        else
        {
            Debug.LogWarning("KillCountDownerUI not found in the scene.");
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        if (clip != null && enemyAudioSource != null)
        {
            enemyAudioSource.PlayOneShot(clip);
        }
    }
}
