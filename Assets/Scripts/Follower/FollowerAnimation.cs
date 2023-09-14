using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerAnimation : PlayerAnimation
{
    FollowerController followerController;
    Animator followerAnim;
    Rigidbody2D followerRb;
    private void Awake()
    {
        followerController = GetComponent<FollowerController>();
        followerAnim = GetComponent<Animator>();
        followerRb = GetComponent<Rigidbody2D>();
    }
    protected override void SetAnimation()
    {
        followerAnim.SetFloat("velocity", Mathf.Abs(followerRb.velocity.x) + Mathf.Abs(followerRb.velocity.y));
        followerAnim.SetBool("followerDown", followerController.followerDown);
    }
}
