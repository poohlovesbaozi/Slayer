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
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask playerLayer;
    Vector3 targetPos;
    bool spawning;
    private void Start()
    {
        spawning = false;
        currentAmount = 0;
        waitForSpawnInterval = new(spawnInterval);
    }
    private void Update()
    {
        if (DetectPlayer() && !spawning)
        {
            StartCoroutine(SpawnMinions());
        }
    }
    bool DetectPlayer()
    {
        var obj = Physics2D.OverlapCircle(transform.position, checkRadius, playerLayer);
        if (obj)
        {
            targetPos = obj.transform.position;
            return true;
        }
        return false;
    }
    IEnumerator SpawnMinions()
    {
        spawning = true;
        while (currentAmount < maxAmount)
        {
            yield return waitForSpawnInterval;
            PoolManager.Release(minion, transform.position);
            currentAmount++;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
