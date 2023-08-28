using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("检测")]
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float checkRadius;
    [Header("数值")]
    [SerializeField] float hitForce;
    [SerializeField] float spd;
    [Header("状态")]
    [SerializeField] bool isHit;
    [Header("组件")]
    public Transform attacker;
    Animator anim;
    Rigidbody2D rb;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    protected virtual void Move()
    {
        
    }
    Vector2 DetectTarget()
    {
        var player = Physics2D.OverlapCircle(transform.position, checkRadius, playerLayer);
        return player.transform.position;
    }
    public void OnTakeDamage(Transform attacker)
    {
        this.attacker = attacker;
        isHit = true;
        anim.SetTrigger("Hit");
        Vector2 dir = (transform.position - attacker.position).normalized;
        StartCoroutine(OnHurt(dir));
    }
    IEnumerator OnHurt(Vector2 dir)
    {
        rb.AddForce(dir * hitForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        isHit = false;

    }
}
