using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBossNecromancer : Enemy
{

    protected override void Awake()
    {
        base.Awake();
        moveState = new NecromancerMoveState();
        skill_1State = new NecromancerSkill_1State();
        skill_2State = new NecromancerSkill_2State();
        skill_3State = new NecromancerSkill_3State();
    }
    public void Skill(AnimationEvent animationEvent)
    {
        for (int i = 0; i < animationEvent.intParameter; i++)
        {
            PoolManager.Release((GameObject)animationEvent.objectReferenceParameter, transform.position);
        }
    }

}
