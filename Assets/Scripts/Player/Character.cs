using UnityEngine.Events;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    [Header("组件")]
    Animator anim;
    [Header("数值")]
    public CharacterStats stats;

    [Header("免疫伤害")]
    [SerializeField] float invulnerableDuration;
    float invulnerableCounter;
    public bool isInvulnerable;
    [Header("事件")]
    [SerializeField]VoidEventSO newGameEvent;
    [SerializeField] CharacterEventSO OnLevelChangeEvent;
    public UnityEvent<Character> OnGemChange;
    public UnityEvent<Character> OnHealthChange;
    public UnityEvent OnDie;
    private void Awake() {
        anim=GetComponent<Animator>();
        stats=stats.GetComponent<CharacterStats>();
    }

    private void OnEnable()
    {
        //主要是follower血量更新
        newGameEvent.OnEventRaised+=NewGame;
        stats.CurrentHp = stats.MaxHp;
    }
    private void Start()
    {
        
    }
    private void OnDisable() {
        newGameEvent.OnEventRaised-=NewGame;
    }

    private void NewGame()
    {
        stats.AzureGem=0;
        stats.Level=1;
        stats.Exp=0;
        stats.ExpToNextLevel=stats.Level*50;
    }

    private void Update()
    {
        // OnHealthChange.Invoke(this);
        if (isInvulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if (invulnerableCounter <= 0)
            {
                isInvulnerable = false;
            }
        }
    }
    public void TakeDamage(Attack attacker)
    {
        if (isInvulnerable)
        {
            return;
        }
        anim.SetTrigger("hit");
        if (stats.CurrentHp >= attacker.damage)
        {
            stats.CurrentHp -= attacker.damage;
            TriggerInvulnerable();
        }
        else
        {
            stats.CurrentHp = 0;
            //死了
            OnDie?.Invoke();
        }
        OnHealthChange?.Invoke(this);
    }
    public void LevelUp(){
        if (stats.Exp>=stats.ExpToNextLevel){
            int levelToAdd=stats.Exp/stats.ExpToNextLevel;
            stats.AbilityPoint+=levelToAdd;
            stats.Level+=levelToAdd;
            stats.Exp=stats.Exp%stats.ExpToNextLevel;
            stats.ExpToNextLevel=stats.Level*50;
            OnLevelChangeEvent?.RaiseEvent(this);
        }
    }
    public void TriggerInvulnerable()
    {
        if (!isInvulnerable)
        {
            isInvulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
}
