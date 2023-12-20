using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        moveState=new MushroomMoveState();
        skill_1State=new MushroomAttackState();
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
