using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("属性")]
    [SerializeField] float flySpd;
    public Vector2 shootDir;

    private void OnEnable()
    {
        StartCoroutine(FlyTowardsEnemy());
    }
    //需要在disable的时候停止协程，否则协程会一直执行，其中的参数不会更新。
    private void OnDisable() {
        StopCoroutine(FlyTowardsEnemy());
    }
    IEnumerator FlyTowardsEnemy()
    {
        while (gameObject.activeSelf)
        {
            transform.Translate(shootDir * flySpd * Time.deltaTime);
            yield return null;
        }

    }


}
