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
            currentEnemy.wizardFire?.SetActive(true);
        else if (a == 2)
            currentEnemy.wizardFire_1?.SetActive(true);
        else
        {
            currentEnemy.wizardFire?.SetActive(true);
            currentEnemy.wizardFire_1?.SetActive(true);
        }
    }

    public override void OnExit()
    {
        currentEnemy.wizardFire?.SetActive(false);
        currentEnemy.wizardFire_1?.SetActive(false);
    }

    public override void PhysicsUpdate()
    {
    }
}
