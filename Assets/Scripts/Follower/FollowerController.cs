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
    protected override void Move()
    {
        followerRb.velocity = ((target.position - transform.position) * followerSpd).normalized;
        //控制角色面朝方向
        followerFaceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0)
            followerFaceDir = 1;
        if (inputDirection.x < 0)
            followerFaceDir = -1;

        transform.localScale = new Vector3(followerFaceDir, 1, 1);
    }
    protected override void DetectEnemy(){
        if (playerCharacter.azureGem>0){
            base.DetectEnemy();
        }
    }
    protected override void Fire(){
        base.Fire();
        playerCharacter.azureGem--;
    }
}
