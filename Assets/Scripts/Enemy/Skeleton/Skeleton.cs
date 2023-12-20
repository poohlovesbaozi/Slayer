using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
   protected override void Awake()
    {
        base.Awake();
        moveState = new SkeletonMoveState();
        skill_1State = new SkeletonAttackState();
        skill_2State=new SkeletonShieldState();
    }
    public override void OnDie()
    {
        base.OnDie();
        anim.SetBool("dead", true);
    }
    public void VanishToDie()
    {
        gameObject.SetActive(false);
    }
    public void FinishAttack(){
        SwitchState(EnemyState.Move);
    }
}
