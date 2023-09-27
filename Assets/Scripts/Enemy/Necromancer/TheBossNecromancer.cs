using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBossNecromancer : Enemy
{
    [SerializeField] GameObject follower;
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
    public override void OnDie()
    {
        anim.SetBool("dead",true);
    }
    public void VanishToDie(){
        follower.transform.position=new Vector3(transform.position.x,transform.position.y,0);     
        follower.SetActive(true);
        gameObject.SetActive(false);
    }

}
