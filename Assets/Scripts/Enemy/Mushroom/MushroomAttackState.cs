using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAttackState : BaseState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.rb.velocity = Vector3.zero;
        currentEnemy.anim.SetTrigger("attack");
        Fire();
    }
    public override void LogicUpdate()
    {
    }

void Fire()
    {
        if (currentEnemy.projectile_0)
        {
            Vector3 shootDir = currentEnemy.target.position-currentEnemy.transform.position;
            PoolManager.Release(currentEnemy.projectile_0, currentEnemy.transform.position, shootDir);
        }
    }

    public override void PhysicsUpdate()
    {
    }
    public override void OnExit()
    {
    }
}
