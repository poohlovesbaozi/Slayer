using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform target;
    Vector2 moveDir;
    bool moving=false;
    private void Update()
    {
        if (CheckReachable() && !moving)
        {
            moving=true;
            moveDir = target.position - transform.position;
            StartCoroutine(MoveToTarget(moveDir));
        }
    }
    private void OnDisable()
    {
        StopCoroutine(MoveToTarget(moveDir));
    }

    IEnumerator MoveToTarget(Vector2 moveDir)
    {
        transform.Translate(moveDir/100);
        yield return null;
        moving=false;
    }
    private void OnTriggerStay2D(Collider2D other) {
        // if (other.name=="player")
        gameObject.SetActive(false);
    }

    bool CheckReachable()
    {
        var obj = Physics2D.OverlapCircle(transform.position, checkRadius, playerLayer);
        if (obj)
        {
            target = obj.transform;
            return true;
        }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
