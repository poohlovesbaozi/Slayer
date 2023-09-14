using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEditor.Callbacks;
using UnityEngine;

public class FollowerController : PlayerController
{
    [SerializeField] Transform target;
    Rigidbody2D followerRb;
    [SerializeField] Character playerCharacter;
    [SerializeField] float followerSpd;
    [SerializeField] float stopDistance;
    public bool followerDown;
    int followerFaceDir;
    [Header("等待救援参数")]
    [SerializeField] float rescueDuration;
    [SerializeField] float rescueCheckRadius;
    [SerializeField] LayerMask playerLayer;
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
        followerDown = true;
        gameObject.layer = LayerMask.NameToLayer("Injured");
    }
    private void ToBeRescued()
    {
        var rescueTime = new WaitForSeconds(rescueDuration);
        if (Physics2D.OverlapCircle(transform.position, rescueCheckRadius, playerLayer))
        {
            StartCoroutine(BeingRescued(rescueTime));
        }
        StopCoroutine(BeingRescued(rescueTime));
    }
    IEnumerator BeingRescued(WaitForSeconds rescueTime)
    {
        //TODO set rescue progress bar active
        yield return rescueTime;
        if (followerDown)
        GetComponent<Character>().hp += 50;
        followerDown = false;
    }
    protected override void DetectEnemy()
    {
        if (playerCharacter.azureGem > 0)
        {
            base.DetectEnemy();
        }
    }
    protected override void Fire()
    {
        base.Fire();
        playerCharacter.azureGem--;
    }
}
