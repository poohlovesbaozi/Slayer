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
        currentEnemy = enemy;
        currentEnemy.anim.SetTrigger("attack");
        int a = Random.Range(0, 3);
        if (a == 1)
            currentEnemy.projectile_0?.SetActive(true);
        else if (a == 2)
            currentEnemy.projectile_1?.SetActive(true);
        else
        {
            currentEnemy.projectile_0?.SetActive(true);
            currentEnemy.projectile_1?.SetActive(true);
        }
    }

    public override void OnExit()
    {
        currentEnemy.projectile_0?.SetActive(false);
        currentEnemy.projectile_1?.SetActive(false);
    }

    public override void PhysicsUpdate()
    {
    }
}
