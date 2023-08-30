using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("检测")]
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float checkRadius;
    [SerializeField] Vector2 moveDir;
    [Header("数值")]
    [SerializeField] float hitForce;
    [SerializeField] float spd;
    [Header("状态")]
    [SerializeField] bool isHit;
    [Header("组件")]
    public Transform attacker;
    [SerializeField] Transform target;
    Animator anim;
    Rigidbody2D rb;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        anim.SetFloat("velocity", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
    }
    private void FixedUpdate()
    {
        Move();
    }
    protected virtual void Move()
    {
        if (DetectTarget())
        {
            int faceDir=(int) transform.localScale.x;
            moveDir = target.position - transform.position;
            rb.velocity = moveDir * spd;
            if (moveDir.x>0){
                faceDir=1;
            }
            if (moveDir.x<0){
                faceDir=-1;
            }
            transform.localScale=new Vector3(faceDir,1,1);
        }
    }
    bool DetectTarget()
    {
        var target = Physics2D.OverlapCircle(transform.position, checkRadius, playerLayer);
        if (target)
        {
            this.target = target.transform;
            return true;
        }
        return false;
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
    public void OnDie(){
        
        gameObject.SetActive(false);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
