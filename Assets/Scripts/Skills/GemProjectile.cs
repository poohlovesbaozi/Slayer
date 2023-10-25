using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemProjectile : Projectile
{
    [SerializeField] Character playerCharacter;
    bool firstTime;
    private void Awake() {
        playerCharacter=GameObject.Find("@Player")?.GetComponent<Character>();
        firstTime=true;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        //第一次执行时，即生成pool时，不执行，之后每次生成都执行一次。
        if (!firstTime)
        playerCharacter.stats.AzureGem--;
        firstTime=false;
    }
}