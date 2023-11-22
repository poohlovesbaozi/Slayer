using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("属性")]
    [SerializeField] float flySpd;
    Rigidbody2D rb;
    public Vector2 shootDir;

    protected virtual void OnEnable()
    {
        rb=GetComponent<Rigidbody2D>();
        StartCoroutine(FlyTowardsEnemy());
        //TODO play audio clip
    }
    //需要在disable的时候停止协程，否则协程会一直执行，其中的参数不会更新。
    private void OnDisable() {
        StopCoroutine(FlyTowardsEnemy());
    }
    IEnumerator FlyTowardsEnemy()
    {
        while (gameObject.activeSelf)
        {
            rb.AddForce(shootDir*flySpd,ForceMode2D.Impulse);
            yield return null;
        }

    }


}
