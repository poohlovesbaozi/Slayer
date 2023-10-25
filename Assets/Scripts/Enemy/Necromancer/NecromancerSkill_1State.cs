using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerSkill_1State : BaseState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.anim.SetTrigger("skill1");
#if UNITY_EDITOR
        Debug.Log("skill_1 state");
#endif
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

