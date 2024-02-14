using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemProjectile : Projectile
{
    [Header("组件")]
    [SerializeField] Character playerCharacter;
    [SerializeField] Character susCharacter;
    CharacterStats stats;
    int atk;
    [Header("事件")]
    [SerializeField] CharacterEventSO onGemChangeEvent;
    [SerializeField] VoidEventSO onNecromancerDie;
    bool firstTime;
    protected override void Awake()
    {
        base.Awake();
        playerCharacter = GameObject.Find("@Player")?.GetComponent<Character>();
        
        firstTime = true;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        onNecromancerDie.OnEventRaised+=GetSusChar;
        if (FollowersData.followers.Count > 1)
        {
            attack.currentDamage += atk;//this line seems have a problem.
        }
        //第一次执行时，即生成pool时，不执行，之后每次生成都执行一次。
        if (!firstTime)
            playerCharacter.stats.AzureGem--;
        firstTime = false;
        onGemChangeEvent.RaiseEvent(playerCharacter);
    }
    private void GetSusChar()
    {
        susCharacter = GameObject.Find("@MiniSuspiciousMerchant")?.GetComponent<Character>();
        stats=susCharacter.stats;
        atk=stats.Attack;
    }
}