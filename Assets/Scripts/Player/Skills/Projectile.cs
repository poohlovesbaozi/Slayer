using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("属性")]
    [SerializeField] float flySpd;
    [SerializeField] float attackRate;
    [SerializeField] float range;
    public Vector2 shootDir;
    Vector2 moveDir;
    private void Start() {
        moveDir=shootDir.normalized;
    }
    private void OnEnable()
    {
        StartCoroutine(FlyTowardsEnemy());
    }

    IEnumerator FlyTowardsEnemy()
    {
        while (gameObject.activeSelf)
        {
            transform.Translate(moveDir * flySpd * Time.deltaTime);
            yield return null;
        }

    }


}
