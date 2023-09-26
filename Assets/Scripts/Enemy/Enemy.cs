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
    public float spd;

    [Header("组件")]
    public Transform attacker;
    [SerializeField] public Transform target;
    [HideInInspector]public Animator anim;
    [HideInInspector]public Rigidbody2D rb;
    [HideInInspector]public Character character;
    BaseState currentState;
    protected BaseState moveState;
    protected BaseState skill_1State;
    protected BaseState skill_2State;
    protected BaseState skill_3State;
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        character=GetComponent<Character>();
    }
    private void OnEnable() {
        currentState=moveState;
        currentState.OnEnter(this);
    }
    protected virtual void Update()
    {
        currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currentState.LogicUpdate();

    }
    private void OnDisable() {
        currentState.OnExit();
    }

    public bool DetectTarget()
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
        anim.SetTrigger("Hit");
        //TODO play audio clip 
        Vector2 dir = (transform.position - attacker.position).normalized;
        rb.AddForce(dir * hitForce, ForceMode2D.Impulse);
    }
    public virtual void OnDie(){     
        gameObject.SetActive(false);
    }
    public void SwitchState(EnemyState state){
        var newState=state switch{
            EnemyState.Move=>moveState,
            EnemyState.Skill_1=>skill_1State,
            EnemyState.Skill_2=>skill_2State,
            EnemyState.Skill_3=>skill_3State,
            _=>null
        };
        currentState.OnExit();
        currentState=newState;
        currentState.OnEnter(this);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
