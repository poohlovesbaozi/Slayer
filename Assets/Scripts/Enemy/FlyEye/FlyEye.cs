using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        moveState=new FlyEyeMoveState();
        skill_1State=new FlyEyeSkillState();
    }
    public override void OnDie()
    {
        anim.SetBool("dead",true);
    }
    public void VanishToDie(){
        gameObject.SetActive(false);
    }
}
