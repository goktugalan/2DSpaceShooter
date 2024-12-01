using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies;

    private int SpawnXPos = 18;
    public TextMeshProUGUI scoreText;
    public int totalScore;
    [SerializeField] private float enemySpawnRate = 4;
    private Vector2 asteroidSpawnPos = new Vector2(15, 11);

    void Start()
    {
        StartCoroutine(EnemySpawnController());
        scoreText.text = "Shoot!";
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(SpawnXPos, Random.Range(-7.5f, 7.5f));
        int randomIndex = Random.Range(0, enemies.Capacity);
        GameObject randomEnemyInst = enemies[randomIndex];
        if (randomEnemyInst.CompareTag("Enemy 1") || randomEnemyInst.CompareTag("Enemy"))
        {
            Instantiate(randomEnemyInst, spawnPos, randomEnemyInst.transform.rotation);
        }
        else if (randomEnemyInst.CompareTag("Asteroid"))
        {
            Instantiate(randomEnemyInst, asteroidSpawnPos, randomEnemyInst.transform.rotation);
        }
    }


    IEnumerator EnemySpawnController()
    {
        InvokeRepeating("SpawnEnemy", 2, enemySpawnRate);
        while (true)
        {
            yield return new WaitForSeconds(10f); // Wait for 10 seconds
            enemySpawnRate -= 0.3f; // Decrease spawn rate by 0.5
            enemySpawnRate = Mathf.Max(enemySpawnRate, 1f); // Ensure spawn rate doesn't go below 0.1
            CancelInvoke("SpawnEnemy"); // Cancel existing InvokeRepeating
            InvokeRepeating("SpawnEnemy", 2, enemySpawnRate);
        }
    }
}
