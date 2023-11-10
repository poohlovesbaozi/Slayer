using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeMoveState : BaseState
{
    float waitCounter;
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.minionStats.CurrentSpd = currentEnemy.minionStats.NormalSpd;
        waitCounter = currentEnemy.minionStats.WaitDuration;
    }
    public override void LogicUpdate()
    {
        currentEnemy.anim.SetFloat("velocity", Mathf.Abs(currentEnemy.rb.velocity.x) + Mathf.Abs(currentEnemy.rb.velocity.y));
    }
    void Move()
    {
        if (waitCounter > 0)
            waitCounter -= Time.deltaTime;
        if (currentEnemy.DetectTarget())
        {
            int faceDir = (int)currentEnemy.transform.localScale.x;
            //改了怪物的移动方向就会出问题
            Vector3 moveDir = currentEnemy.target.position - currentEnemy.transform.position;
            currentEnemy.rb.velocity = (moveDir * currentEnemy.minionStats.CurrentSpd).normalized;
            if (currentEnemy.target.position.x - currentEnemy.transform.position.x > 0)
            {
                faceDir = 1;
            }
            if (currentEnemy.target.position.x - currentEnemy.transform.position.x < 0)
            {
                faceDir = -1;
            }
            currentEnemy.transform.localScale = new Vector3(faceDir, 1, 1);
        }
    }

    public override void PhysicsUpdate()
    {
        if (currentEnemy.target && waitCounter <= 0 && Vector3.Distance(currentEnemy.transform.position, currentEnemy.target.position) <= currentEnemy.minionStats.WaitDistance && currentEnemy.DetectTarget())
        {
            currentEnemy.SwitchState(EnemyState.Skill_1);
        }
        Move();
    }
    public override void OnExit()
    {

    }
}
