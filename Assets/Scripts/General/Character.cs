using UnityEngine.Events;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    [Header("数值")]
    public float maxHp;
    public float hp;
    public int azureGem;
    public int currentGem;

    [Header("免疫伤害")]
    [SerializeField] float invulnerableDuration;
    [SerializeField] float invulnerableCounter;
    [SerializeField] bool isInvulnerable;
    [Header("事件")]
    public UnityEvent<Character> OnGemChange;
    public UnityEvent<Character> OnHealthChange;
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDie;

    private void Start()
    {
        currentGem=0;
        OnGemChange?.Invoke(this);
        OnHealthChange?.Invoke(this);
    }
    private void OnEnable()
    {
        hp=maxHp;
    }
    private void Update()
    {
        if (currentGem!=azureGem){
            currentGem=azureGem;
            OnGemChange?.Invoke(this);
        }
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
        if (hp >= attacker.damage)
        {
            hp -= attacker.damage;
            TriggerInvulnerable();
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            hp = 0;
            //死了
            OnDie?.Invoke();
        }
        OnHealthChange?.Invoke(this);
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
