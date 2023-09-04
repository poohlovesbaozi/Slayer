using UnityEngine.Events;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float maxHp;
    public float hp;
    [Header("组件")]
    [SerializeField] CharacterStats characterStats;
    [Header("免疫伤害")]
    [SerializeField] float invulnerableDuration;
    [SerializeField] float invulnerableCounter;
    [SerializeField] bool isInvulnerable;

    public UnityEvent<Character> OnHealthChange;
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDie;
    private void Awake() {
        characterStats=GetComponent<CharacterStats>();
    }
    private void Start()
    {
        OnHealthChange?.Invoke(this);
    }
    private void OnEnable()
    {
        characterStats.maxHp=maxHp;
        hp=maxHp;
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
