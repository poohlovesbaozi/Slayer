using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    [Header("组件")]
    private Rigidbody2D rb;
    [SerializeField]Image stickImage;
    [SerializeField] GameObject projectile;
    [SerializeField]protected CharacterStats stats;
    [Header("检测")]
    [SerializeField]LayerMask enemyLayer;
    [SerializeField] Vector2 bottomOffset;
    Vector2 touchPos;
    public bool isDead;
    [Header("移动")]
    int faceDir;
    Vector2 inputDirection;
    [Header("攻击")]
    Vector2 shootDir;
    [SerializeField]bool canFire;

    protected virtual void Awake()
    {
        
        enemyLayer=LayerMask.GetMask("Enemy");
        inputControl = new PlayerInputControl();
        rb = GetComponent<Rigidbody2D>();
        inputControl.GamePlay.StickFollow.performed += ctx =>
        {
            stickImage.enabled=true;
            touchPos=inputControl.GamePlay.TouchPos.ReadValue<Vector2>();
            stickImage.rectTransform.position=new Vector3(touchPos.x,touchPos.y,0);
        };
        inputControl.GamePlay.StickFollow.canceled += ctx =>
        {
            stickImage.enabled=false;
        };
    }
    protected virtual void Start()
    {
        shootDir = new Vector2(0, 0);
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
        rb.velocity = inputDirection * stats.Spd * Time.deltaTime;
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
        //player stop to move after dying.
        rb.velocity=Vector3.zero;
        isDead = true;
        inputControl.GamePlay.Disable();
    }
    #region 开火
    protected virtual void DetectEnemy()
    {
        var obj = Physics2D.OverlapCircle(transform.position, stats.CheckRadius, enemyLayer);
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
        yield return new WaitForSeconds(stats.FireInterval);
        canFire = true;
    }
    #endregion
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, stats.CheckRadius);
    }
}
