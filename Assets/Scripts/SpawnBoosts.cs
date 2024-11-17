using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoosts : MonoBehaviour
{
    public List<GameObject> boosts;
    private int SpawnXPos = 18;

    void Start()
    {
        StartCoroutine(SpawnBoostsCoroutine());
    }

    IEnumerator SpawnBoostsCoroutine()
    {
        while (true)
        {
            SpawnBoost();
            yield return new WaitForSeconds(1f); // Spawns every 1 second (adjust as needed)
        }
    }

    private void SpawnBoost()
    {
        Vector3 spawnBoostPos = new Vector3(SpawnXPos, Random.Range(-7.5f, 7.5f));
        int randomBoostIndex = Random.Range(0, boosts.Count);
        GameObject randomBoostInst = boosts[randomBoostIndex];
        Debug.Log(randomBoostInst);
        Instantiate(randomBoostInst, spawnBoostPos, randomBoostInst.transform.rotation);
    }
}
