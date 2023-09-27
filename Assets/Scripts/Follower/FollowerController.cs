using System;
using System.Collections;
using System.Security.Permissions;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class FollowerController : PlayerController
{
    [SerializeField] Image helpSign;
    [SerializeField] Transform target;
    Rigidbody2D followerRb;
    [SerializeField] Character playerCharacter;
    Character followerCharacter;
    [SerializeField] float followerSpd;
    [SerializeField] float stopDistance;
    public bool followerDown;
    int followerFaceDir;
    [Header("等待救援参数")]
    [SerializeField] float rescueDuration;
    float rescueCounter;
    [SerializeField] float rescueCheckRadius;
    [SerializeField] LayerMask playerLayer;
    protected override void Start()
    {
        base.Start();
        followerCharacter = GetComponent<Character>();
        followerDown = true;
        helpSign.enabled = followerDown;
        followerCharacter.hp = 0;
    }
    protected override void Awake()
    {
        followerRb = GetComponent<Rigidbody2D>();
    }
    //父类的inputControl不需要
    protected override void OnEnable()
    {

    }
    protected override void OnDisable()
    {

    }
    protected override void Update()
    {

    }
    private void FixedUpdate()
    {
        if (!followerDown)
        {
            DetectEnemy();
            Move();
        }
        else
        {
            ToBeRescued();
        }
    }
    protected override void Move()
    {
        if (Vector3.Distance(transform.position, target.position) > stopDistance)
        {
            followerRb.velocity = (target.position - transform.position) * followerSpd * Time.deltaTime;
        }
        else
        {
            followerRb.velocity = Vector3.zero;
        }
        //控制角色面朝方向
        followerFaceDir = (int)transform.localScale.x;
        if (followerRb.velocity.x > 0)
            followerFaceDir = 1;
        if (followerRb.velocity.x < 0)
            followerFaceDir = -1;

        transform.localScale = new Vector3(followerFaceDir, 1, 1);
    }
    protected override void PlayerDie()
    {
        helpSign.enabled = true;
        followerDown = true;
        rescueCounter = rescueDuration;
        followerRb.velocity=Vector3.zero;
        gameObject.layer = LayerMask.NameToLayer("Injured");
    }
    private void ToBeRescued()
    {
        //TODO maybe sound?
        if (Physics2D.OverlapCircle(transform.position, rescueCheckRadius, playerLayer))
        {
            rescueCounter -= Time.deltaTime;
            //逐渐增加血条，血条满时就会被救起
            followerCharacter.hp+=Time.deltaTime/rescueDuration*followerCharacter.maxHp;
            if (rescueCounter <= 0)
            {
                followerCharacter.hp=70;
                followerDown = false;
                helpSign.enabled = false;
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
        else{
            followerCharacter.hp=0;
            rescueCounter=rescueDuration;
        }
    }

    protected override void DetectEnemy()
    {
        if (playerCharacter.azureGem > 0)
        {
            base.DetectEnemy();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rescueCheckRadius);
    }
}
