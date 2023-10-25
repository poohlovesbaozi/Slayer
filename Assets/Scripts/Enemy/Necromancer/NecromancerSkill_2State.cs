using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerSkill_2State : BaseState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.anim.SetTrigger("skill2");
#if UNITY_EDITOR
        Debug.Log("skill_2 state");
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
