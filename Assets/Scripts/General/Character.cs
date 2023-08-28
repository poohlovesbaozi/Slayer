using UnityEngine.Events;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("基本属性")]
    public float hp;
    public float maxHp;
    [Header("免疫伤害")]
    public float invulnerableDuration;
    private float invulnerableCounter;
    public bool isInvulnerable;

    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDie;
    private void Start()
    {
        hp = maxHp;
    }
    private void Update()
    {
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
