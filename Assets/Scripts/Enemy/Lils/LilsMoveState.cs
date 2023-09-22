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
        Move();
    }
    void Move()
    {
        if (currentEnemy.DetectTarget())
        {
            int faceDir = (int)currentEnemy.transform.localScale.x;
            currentEnemy.rb.velocity = (currentEnemy.target.position - currentEnemy.transform.position * currentEnemy.spd).normalized;
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

    }
    public override void OnExit()
    {

    }
}
