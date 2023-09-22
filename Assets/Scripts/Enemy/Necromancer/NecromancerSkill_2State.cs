using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerSkill_2State : BaseState
{
    public override void LogicUpdate()
    {
        
    }

    public override void OnEnter(Enemy enemy)
    {
                currentEnemy = enemy;
#if UNITY_EDITOR
        Debug.Log("skill_2 state");
#endif
    }

    public override void OnExit()
    {
        
    }

    public override void PhysicsUpdate()
    {
        
    }
}
