using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] int expValue;
    [SerializeField] int gemValue;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform target;
    [SerializeField] GameObject player;
    Character playerCharacter;
    [Header("监听")]
    [SerializeField] SceneLoadEventSO loadEvent;
    [Header("广播")]
    [SerializeField] CharacterEventSO OnExpChangeEvent;
    [SerializeField] CharacterEventSO onGemChangeEvent;
    
    Vector2 moveDir;
    bool moving;
    private void OnEnable()
    {
        player=GameObject.Find("@Player");
        playerCharacter=player?.GetComponent<Character>();
        moving = false;
        loadEvent.loadRequestEvent+=OnLoadRequestEvent;
    }
    private void Update()
    {
        if (CheckReachable() && !moving)
        {
            moving = true;
            moveDir = target.position - transform.position;
            StartCoroutine(MoveToTarget(moveDir));
        }
    }
    private void OnDisable()
    {
        loadEvent.loadRequestEvent+=OnLoadRequestEvent;
    }

    private void OnLoadRequestEvent(GameSceneSO arg0, Vector3 arg1, bool arg2)
    {
        gameObject.SetActive(false);
    }

    IEnumerator MoveToTarget(Vector2 moveDir)
    {
        transform.Translate(moveDir / 100);
        yield return null;
        moving = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //ui变动
        onGemChangeEvent?.RaiseEvent(playerCharacter);
        playerCharacter.stats.AzureGem+=gemValue;
        playerCharacter.stats.Exp+=expValue;
        playerCharacter.LevelUp();
        OnExpChangeEvent?.RaiseEvent(playerCharacter);
        gameObject.SetActive(false);
    }

    bool CheckReachable()
    {
        var obj = Physics2D.OverlapCircle(transform.position, checkRadius, playerLayer);
        if (obj)
        {
            target = obj.transform;
            return true;
        }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
