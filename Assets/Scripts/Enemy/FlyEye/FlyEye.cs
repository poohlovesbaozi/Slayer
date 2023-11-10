using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        moveState=new FlyEyeMoveState();
        skill_1State=new FlyEyeSkillState();
    }
    public override void OnDie()
    {
        base.OnDie();
        anim.SetBool("dead",true);
    }
    public void VanishToDie(){
        gameObject.SetActive(false);
    }
    public void Charge(){
        Vector2 dir=((Vector2)(target.position-transform.position)).normalized*minionStats.DashSpd;
        rb.AddForce(dir,ForceMode2D.Impulse);
    }
    public void StopCharging(){
        rb.velocity=Vector2.zero;
        SwitchState(EnemyState.Move);
    }
}
