using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeSkillState : BaseState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.anim.SetTrigger("attack");
    }
    public override void LogicUpdate()
    {

    }
    public override void PhysicsUpdate()
    {
    }
    public override void OnExit()
    {

    }
}
