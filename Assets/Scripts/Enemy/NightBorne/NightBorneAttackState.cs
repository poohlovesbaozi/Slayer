using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneAttackState : BaseState
{
    bool canFire;
    float fireInterval=1f;
    float fireCounter;
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy=enemy;
        currentEnemy.anim.SetTrigger("attack");
        fireCounter=fireInterval;
        canFire=true;
    }
    void Fire()
    {
        fireCounter-=Time.deltaTime;
        canFire=fireCounter<=0;
        if (currentEnemy.projectile_0 && canFire)
        {
            Vector3 shootDir = currentEnemy.target.position-currentEnemy.transform.position;
            PoolManager.Release(currentEnemy.projectile_0, currentEnemy.transform.position, shootDir);
            canFire=false;
            fireCounter=fireInterval;
        }
    }
    public override void LogicUpdate()
    {
    }
    public override void PhysicsUpdate()
    {
        Fire();
    }
    public override void OnExit()
    {
    }
}
