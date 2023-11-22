using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMoveState : BaseState
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
    public override void PhysicsUpdate()
    {
        if (currentEnemy.target && waitCounter <= 0 && Vector3.Distance(currentEnemy.transform.position, currentEnemy.target.position) <= currentEnemy.minionStats.WaitDistance)
        {
            currentEnemy.SwitchState(EnemyState.Skill_1);
        }
        else
            Move();
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
            if (Vector3.Distance(currentEnemy.transform.position, currentEnemy.target.position) > currentEnemy.minionStats.WaitDistance)
            {
                currentEnemy.rb.velocity = moveDir.normalized * currentEnemy.minionStats.CurrentSpd;
            }
            else
            {
                currentEnemy.rb.velocity = Vector3.zero;
            }
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
    public override void OnExit()
    {
    }
}


