using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCharacter : MonoBehaviour
{
   [SerializeField] MinionStats stats;
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDie;
    private void OnEnable()
    {
        stats.CurrentHp = stats.MaxHp;
    }
    public void TakeDamage(Attack attacker)
    {
        print("get hit");
        if (stats.CurrentHp >= attacker.damage)
        {
            stats.CurrentHp -= attacker.damage;

            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            stats.CurrentHp = 0;
            //死了
            OnDie?.Invoke();
        }
    }
}
