using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FollowerController : PlayerController
{
    [Header("player")]
    [SerializeField] Character playerCharacter;
    [SerializeField] Transform target;
    [SerializeField] Image helpSign;
    Rigidbody2D followerRb;
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
        followerCharacter.stats.CurrentHp = 0;
    }
    protected override void Awake()
    {
        followerRb = GetComponent<Rigidbody2D>();
    }
    //父类的inputControl不需要
    protected override void OnEnable()
    {
        SceneManager.MoveGameObjectToScene(gameObject,SceneManager.GetSceneByName("Persistent"));
        target=GameObject.Find("@Player")?.GetComponent<Transform>();
        playerCharacter=target?.gameObject.GetComponent<Character>();
        if (!FollowersData.followers.Contains(gameObject))
        FollowersData.followers.Add(gameObject);
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
            followerCharacter.stats.CurrentHp+=(int)(Time.deltaTime/rescueDuration*followerCharacter.stats.MaxHp);
            if (rescueCounter <= 0)
            {
                followerCharacter.stats.CurrentHp=70;
                followerDown = false;
                helpSign.enabled = false;
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
        else{
            followerCharacter.stats.CurrentHp=0;
            rescueCounter=rescueDuration;
        }
    }

    protected override void DetectEnemy()
    {
        if (playerCharacter.stats.AzureGem > 0)
        {
            base.DetectEnemy();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rescueCheckRadius);
    }
}
