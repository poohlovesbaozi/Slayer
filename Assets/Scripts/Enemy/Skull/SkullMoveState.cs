using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullMoveState : BaseState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.minionStats.CurrentSpd = currentEnemy.minionStats.NormalSpd;
    }
    public override void LogicUpdate()
    {
        Fly();
    }

    private void Fly()
    {
        if (currentEnemy.DetectTarget())
        {
            Vector3 moveDir = currentEnemy.target.position - currentEnemy.transform.position;
            currentEnemy.transform.Translate(moveDir * currentEnemy.minionStats.CurrentSpd * Time.deltaTime);
        }
    }


    public override void PhysicsUpdate()
    {

    }
    public override void OnExit()
    {

    }
}
