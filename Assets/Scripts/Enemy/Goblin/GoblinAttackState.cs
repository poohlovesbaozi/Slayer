using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttackState : BaseState
{
    public override void OnEnter(Enemy enemy)
    {
        Debug.Log("a");
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
