using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyBehaviour : MonoBehaviour
{
    private GameManager gameManager;
    public int speed, life, scoreToAdd;
    private float enemyFireRate;
    private Rigidbody2D enemyRb;
    [SerializeField] private GameObject enemyBullet, enemyExplosion, enemyGetHit;
    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Enemy1Settings();
        enemyRb.velocity = Vector2.left * speed;
    }

    private void Enemy1Settings()
    {
        if (gameObject.CompareTag("Enemy 1"))
        {
            if (transform.position.x < 8)
            {
                transform.position = new Vector3(8, transform.position.y, transform.position.z);
                EnemyShoot();
            }
        }
    }
    private void EnemyShoot()
    {
        enemyFireRate -= Time.deltaTime;
        if(enemyFireRate <= 0)
        {
            Vector3 bulletSpawnPos = new Vector3(5, transform.position.y);
            Instantiate(enemyBullet, bulletSpawnPos, enemyBullet.transform.rotation);
            enemyFireRate = 2f;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            life -= 1;
            Instantiate(enemyGetHit, transform.position, Quaternion.identity);
            if(life < 1)
            {
                Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                StartCoroutine(WaitToDestroy());
                gameManager.totalScore += scoreToAdd;
                gameManager.scoreText.text = "Score: " + gameManager.totalScore;
            }
        }
    }
    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
