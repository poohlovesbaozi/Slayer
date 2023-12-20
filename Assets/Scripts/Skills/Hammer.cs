using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Projectile
{
    protected override void OnEnable()
    {
        base.OnEnable();
        attack.currentDamage+=FollowersData.followers[0].GetComponent<Character>().stats.Attack;
    }

}
