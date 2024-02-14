using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [Header("事件")]
    [SerializeField] SceneLoadEventSO loadEvent;
    [Header("检测")]
    [SerializeField]LayerMask playerLayer;
    [Header("数值")]

    [SerializeField] GameObject item;

    [Header("组件")]
    public GameObject projectile_0;
    public GameObject projectile_1;
    public MinionStats minionStats;
    [SerializeField] public Transform target;
    [HideInInspector] public Animator anim;
    [HideInInspector] public Rigidbody2D rb;
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

        playerLayer = LayerMask.GetMask("Player");
    }
    private void OnEnable()
    {
        currentState = moveState;
        currentState?.OnEnter(this);
        loadEvent.loadRequestEvent += OnLoadRequestEvent;
    }
    protected virtual void Update()
    {
        currentState?.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currentState?.PhysicsUpdate();

    }
    private void OnDisable()
    {
        loadEvent.loadRequestEvent -= OnLoadRequestEvent;
        currentState?.OnExit();
    }

    private void OnLoadRequestEvent(GameSceneSO arg0, Vector3 arg1, bool arg2)
    {
        //切换场景时关闭所有敌人
        gameObject.SetActive(false);
    }

    public bool DetectTarget()
    {
        var target = Physics2D.OverlapCircle(transform.position, minionStats.CheckRadius, playerLayer);
        if (target)
        {
            this.target = target.transform;
        }
        return target;
    }
    public void OnTakeDamage()
    {
        anim.SetTrigger("hit");
        playAudioEvent?.OnEventRaised(getHitClip);
    }
    public virtual void OnDie()
    {
        if (item && Random.Range(1, minionStats.DropRate) == 1)
            PoolManager.Release(item, transform.position);
        // gameObject.SetActive(false);
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
        Gizmos.DrawWireSphere(transform.position, minionStats.CheckRadius);
    }
}
