using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoosts : MonoBehaviour
{
    public List<GameObject> boosts;
    private int SpawnXPos = 18;
    private PlayerObjectCollider playerObjectCollider;

    void Start()
    {
        playerObjectCollider = FindAnyObjectByType<PlayerObjectCollider>();
        StartCoroutine(SpawnBoostsCoroutine());
    }

    IEnumerator SpawnBoostsCoroutine()
    {
        while (true)
        {
            SpawnBoost();
            yield return new WaitForSeconds(7f);
        }
    }

    private void SpawnBoost()
    {
        if (playerObjectCollider.playerLife > 0)
        {
            Vector3 spawnBoostPos = new Vector3(SpawnXPos, Random.Range(-7.5f, 7.5f));
            int randomBoostIndex = Random.Range(0, boosts.Count);
            GameObject randomBoostInst = boosts[randomBoostIndex];
            Debug.Log(randomBoostInst);
            Instantiate(randomBoostInst, spawnBoostPos, randomBoostInst.transform.rotation);
        }
    }
}
