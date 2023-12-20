using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCharacter : MonoBehaviour
{
   [SerializeField] MinionStats stats;
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDie;
    private void OnEnable()
    {
        stats.CurrentHp = stats.MaxHp;
    }
    public void TakeDamage(Attack attacker)
    {
        if (stats.CurrentHp >= attacker.currentDamage)
        {
            stats.CurrentHp -= attacker.currentDamage;

            OnTakeDamage?.Invoke();
        }
        else
        {
            stats.CurrentHp = 0;
            //死了
            OnDie?.Invoke();
        }
    }
}
