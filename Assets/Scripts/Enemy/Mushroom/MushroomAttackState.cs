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
