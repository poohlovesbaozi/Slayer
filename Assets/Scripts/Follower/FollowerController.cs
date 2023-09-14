using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class FollowerController : PlayerController
{
    [SerializeField] Transform target;
    Rigidbody2D followerRb;
    [SerializeField] Character playerCharacter;
    [SerializeField] float followerSpd;
    [SerializeField] float stopDistance;
    bool waitForRescue;
    int followerFaceDir;
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
        if (!waitForRescue)
        {
            DetectEnemy();
            Move();
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
    protected override void PlayerDie(){
        waitForRescue=true;
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
