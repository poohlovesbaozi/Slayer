using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        moveState = new EvilWizardMoveState();
        skill_1State = new EvilWizardAttackState();
    }
    public void FinishAttack()
    {
        SwitchState(EnemyState.Move);
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
}
