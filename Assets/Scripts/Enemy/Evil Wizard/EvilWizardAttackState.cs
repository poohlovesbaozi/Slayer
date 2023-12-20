using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizardAttackState : BaseState
{
    public override void LogicUpdate()
    {
    }

    public override void OnEnter(Enemy enemy)
    {
        currentEnemy=enemy;
        currentEnemy.anim.SetTrigger("attack");
    }

    public override void OnExit()
    {
    }

    public override void PhysicsUpdate()
    {
    }
}
