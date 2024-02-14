using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] public int damage;
    public int currentDamage;
    [SerializeField] bool deactivateOnCollide;
    private void OnEnable()
    {
        currentDamage = damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<Character>()?.TakeDamage(this);
        }
        else if (other.gameObject.tag == "enemy")
        {
            other.GetComponent<EnemyCharacter>()?.TakeDamage(this);
            gameObject.SetActive(!deactivateOnCollide);
        }
    }
}
