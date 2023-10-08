using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    [SerializeField] SceneLoadEventSO loadEvent;
    [Header("检测")]
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float checkRadius;
    [Header("数值")]
    [SerializeField] float hitForce;
    public float spd;
    [SerializeField] GameObject item;

    [Header("组件")]
    public Transform attacker;
    [SerializeField] public Transform target;
    [HideInInspector] public Animator anim;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Character character;
    [SerializeField] PlayAudioEventSO playAudioEvent;
    [SerializeField] AudioClip getHitClip;
    BaseState currentState;
    protected BaseState moveState;
    protected BaseState skill_1State;
    protected BaseState skill_2State;
    protected BaseState skill_3State;
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }
    private void OnEnable()
    {
        currentState = moveState;
        currentState.OnEnter(this);
        loadEvent.loadRequestEvent+=OnLoadRequestEvent;
    }
    protected virtual void Update()
    {
        currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currentState.PhysicsUpdate();

    }
    private void OnDisable()
    {
        loadEvent.loadRequestEvent-=OnLoadRequestEvent;
        currentState.OnExit();
    }

    private void OnLoadRequestEvent(GameSceneSO arg0, Vector3 arg1, bool arg2)
    {
        gameObject.SetActive(false);
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
        playAudioEvent.OnEventRaised(getHitClip);
        Vector2 dir = (transform.position - attacker.position).normalized;
        rb.AddForce(dir * hitForce, ForceMode2D.Impulse);
    }
    public virtual void OnDie()
    {
        if (item && Random.Range(1, 4) == 1)
            PoolManager.Release(item, transform.position);
        gameObject.SetActive(false);
    }
    public void SwitchState(EnemyState state)
    {
        var newState = state switch
        {
            EnemyState.Move => moveState,
            EnemyState.Skill_1 => skill_1State,
            EnemyState.Skill_2 => skill_2State,
            EnemyState.Skill_3 => skill_3State,
            _ => null
        };
        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter(this);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
