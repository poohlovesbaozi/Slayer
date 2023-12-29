using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonShieldState : BaseState
{
    float waitCounter;
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.rb.velocity = Vector3.zero;
        currentEnemy.anim.SetBool("shield",true);
        waitCounter = currentEnemy.minionStats.WaitDuration;
    }
    public override void LogicUpdate()
    {
        waitCounter -= Time.deltaTime;
        if (waitCounter <= 0)
            currentEnemy.SwitchState(EnemyState.Move);
    }
    public override void PhysicsUpdate()
    {
    }
    public override void OnExit()
    {
        currentEnemy.anim.SetBool("shield",false);
    }
}
