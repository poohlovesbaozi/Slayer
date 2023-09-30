using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilsMoveState : BaseState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
    }
    public override void LogicUpdate()
    {
        currentEnemy.anim.SetFloat("velocity", Mathf.Abs(currentEnemy.rb.velocity.x) + Mathf.Abs(currentEnemy.rb.velocity.y));
    }
    void Move()
    {
        if (currentEnemy.DetectTarget())
        {
            int faceDir = (int)currentEnemy.transform.localScale.x;
            //改了怪物的移动方向就会出问题
            Vector3 moveDir = currentEnemy.target.position - currentEnemy.transform.position;
            currentEnemy.rb.velocity = (moveDir * currentEnemy.spd).normalized;
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
        Move();
    }
    public override void OnExit()
    {

    }
}
