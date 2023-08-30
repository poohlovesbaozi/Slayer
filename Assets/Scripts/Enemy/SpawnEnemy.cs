using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject minion;
    WaitForSeconds waitForSpawnInterval;
    [SerializeField] float spawnInterval;
    Vector2 faceDir;
    [SerializeField] int maxAmount;
    [SerializeField] int currentAmount;
    private void Start()
    {
        currentAmount=0;
        waitForSpawnInterval = new(spawnInterval);
        StartCoroutine(SpawnMinions());
    }
    IEnumerator SpawnMinions()
    {
        while (currentAmount<maxAmount)
        {
            yield return waitForSpawnInterval;
            PoolManager.Release(minion, transform.position);
            currentAmount++;
        }
    }
}
