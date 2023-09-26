using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerSkill_3State : BaseState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.anim.SetTrigger("skill3");
#if UNITY_EDITOR
        Debug.Log("skill_3 state");
#endif
    }
    public override void LogicUpdate()
    {
        currentEnemy.character.isInvulnerable = true;
    }



    public override void PhysicsUpdate()
    {

    }
    public override void OnExit()
    {
        currentEnemy.character.isInvulnerable = false;
    }
}
