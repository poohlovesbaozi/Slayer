using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using TMPro;
using System.Runtime.Remoting.Messaging;


public class FollowerController : PlayerController
{
    [Header("声音")]
    [SerializeField] PlayAudioEventSO playAudioEvent;
    [SerializeField] AudioClip healAudio;
    [SerializeField] bool isSkill;
    [SerializeField] bool needGem;
    [Header("player")]
    Character playerCharacter;
    [SerializeField] Transform target;
    [Header("组件")]
    Character character;
    [SerializeField] Image helpSign;
    Rigidbody2D followerRb;
    // [SerializeField]CharacterStats stats;
    Animator anim;
    [SerializeField] float stopDistance;
    public bool followerDown;
    int followerFaceDir;
    [Header("等待救援参数")]
    [SerializeField] float rescueDuration;
    float rescueCounter;
    [SerializeField] float rescueCheckRadius;
    [SerializeField] LayerMask playerLayer;
    protected override void Awake()
    {
        character = GetComponent<Character>();
        stats = GetComponent<CharacterStats>();
        followerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rescueCounter = rescueDuration;
    }
    //父类的inputControl不需要
    protected override void OnEnable()
    {
        target = GameObject.Find("@Player")?.GetComponent<Transform>();
        playerCharacter = target?.gameObject.GetComponent<Character>();
    }
    protected override void Start()
    {
        stats.CurrentHp = 0;
        base.Start();
        followerDown = true;
        helpSign.enabled = followerDown;
    }
    protected override void OnDisable()
    {

    }

    protected override void Update()
    {

    }
    private void FixedUpdate()
    {
        if (!followerDown)
        {
            DetectEnemy();
            Move();
        }
        else
        {
            ToBeRescued();
        }
    }
    protected override void Move()
    {
        if (Vector3.Distance(transform.position, target.position) > stopDistance)
        {
            followerRb.velocity = (target.position - transform.position) * stats.Spd * Time.deltaTime;
        }
        else
        {
            followerRb.velocity = Vector3.zero;
        }
        //控制角色面朝方向
        followerFaceDir = (int)transform.localScale.x;
        if (followerRb.velocity.x > 0)
            followerFaceDir = 1;
        if (followerRb.velocity.x < 0)
            followerFaceDir = -1;

        transform.localScale = new Vector3(followerFaceDir, 1, 1);
    }
    public override void PlayerDie()
    {
        helpSign.enabled = true;
        followerDown = true;
        rescueCounter = rescueDuration;
        followerRb.velocity = Vector3.zero;
        gameObject.layer = LayerMask.NameToLayer("Injured");
    }
    private void ToBeRescued()
    {

        //TODO maybe sound?
        if (Physics2D.OverlapCircle(transform.position, rescueCheckRadius, playerLayer))
        {
            rescueCounter -= Time.deltaTime;
            //逐渐增加血条，血条满时就会被救起
            // stats.CurrentHp += (int)(Time.deltaTime / rescueDuration * stats.MaxHp);
            stats.CurrentHp++;
            // character.OnHealthChange.Invoke(character);
            if (rescueCounter <= 0)
            {
                stats.CurrentHp = 70;
                followerDown = false;
                helpSign.enabled = false;
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
        else
        {
            stats.CurrentHp = 0;
            rescueCounter = rescueDuration;
        }
        // character.OnHealthChange.Invoke(character);
    }

    protected override void DetectEnemy()
    {
        if (needGem)
        {
            if (playerCharacter.stats.AzureGem > 0)
            {
                base.DetectEnemy();
            }
        }
        else
            base.DetectEnemy();
    }
    protected override void Fire()
    {
        if (!isSkill)
            base.Fire();
        else
            StartCoroutine(HealCoroutine());
    }
    IEnumerator HealCoroutine()
    {
        anim.SetTrigger("attack");
        foreach (GameObject follower in FollowersData.followers)
        {
            Character character = follower?.GetComponent<Character>();
            playAudioEvent?.RaiseEvent(healAudio);
            if (character.stats.CurrentHp < character.stats.MaxHp)
                character.stats.CurrentHp += stats.Attack;
        }
        yield return new WaitForSeconds(stats.FireInterval);
        canFire = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rescueCheckRadius);
    }
}
