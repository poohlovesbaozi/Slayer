using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    [Header("组件")]
    private Rigidbody2D rb;
    [SerializeField] GameObject projectile;
    [Header("数值")]
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] Vector2 bottomOffset;
    [SerializeField] Vector2 shootDir;
    public Vector2 inputDirection;
    public float spd;
    WaitForSeconds waitForFireInterval;
    [SerializeField] float fireInterval;
    [Header("状态")]
    [SerializeField] int faceDir;
    public bool isDead;
    [SerializeField] bool canFire;
    [Header("test")]
    [SerializeField] List<Character> followers;
    [SerializeField] Character followerChar;
    [SerializeField] Attack testAttacker;
    protected virtual void Awake()
    {
        inputControl = new PlayerInputControl();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        shootDir = new Vector2(0, 0);
        waitForFireInterval = new(fireInterval);
    }
    protected virtual void OnEnable()
    {
        inputControl.Enable();
    }
    protected virtual void OnDisable()
    {
        inputControl.Disable();
    }
    protected virtual void Update()
    {
        //directly abstract follower's hp
#if UNITY_EDITOR
        if (inputControl.GamePlay.Test.IsPressed())
        {
            followerChar.TakeDamage(testAttacker);
        }
#endif
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {
            DetectEnemy();
            Move();
        }
    }
    protected virtual void Move()
    {
        //人物移动
        rb.velocity = inputDirection * spd * Time.deltaTime;
        //控制角色面朝方向
        faceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0)
            faceDir = 1;
        if (inputDirection.x < 0)
            faceDir = -1;

        transform.localScale = new Vector3(faceDir, 1, 1);
    }
    protected virtual void PlayerDie()
    {
        isDead = true;
        inputControl.GamePlay.Disable();
    }
    #region 开火
    protected virtual void DetectEnemy()
    {
        var obj = Physics2D.OverlapCircle(transform.position, checkRadius, enemyLayer);
        if (obj && canFire)
        {
            //这边需要的是相对位置
            shootDir = obj.transform.position - transform.position;
            Fire();
            canFire = false;
        }
    }
    protected virtual void Fire()
    {
        StartCoroutine(nameof(FireCoroutine));
    }
    IEnumerator FireCoroutine()
    {
        PoolManager.Release(projectile, transform.position, shootDir);
        yield return waitForFireInterval;
        canFire = true;
    }
    #endregion
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
