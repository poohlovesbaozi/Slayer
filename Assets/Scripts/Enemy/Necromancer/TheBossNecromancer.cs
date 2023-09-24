using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBossNecromancer : Enemy
{
    [SerializeField] GameObject skill_1Minion;
    [SerializeField] int timesToSummonSkill_1;
    protected override void Awake()
    {
        base.Awake();
        moveState = new NecromancerMoveState();
        skill_1State = new NecromancerSkill_1State();
        skill_2State = new NecromancerSkill_2State();
        skill_3State = new NecromancerSkill_3State();
    }
    public void Skill_1()
    {
        for (int i = 0; i < timesToSummonSkill_1; i++)
        {
            PoolManager.Release(skill_1Minion, transform.position);
        }
    }
}
