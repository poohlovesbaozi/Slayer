using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBossNightBorne : Enemy
{
    [SerializeField] TeleportPoint teleportPoint;
    [SerializeField] VoidEventSO OnBossNightBorneDie;
    protected override void Awake()
    {
        base.Awake();
        moveState=new NightBorneMoveState();
        skill_1State=new NightBorneAttackState();
    }
    public void FinishAttack(){
        SwitchState(EnemyState.Move);
    }
    public override void OnDie()
    {
        base.OnDie();
        teleportPoint.gameObject.SetActive(true);
        OnBossNightBorneDie.RaiseEvent();
        anim.SetBool("dead", true);
    }
    public void VanishToDie()
    {
        gameObject.SetActive(false);
    }
}
