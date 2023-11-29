using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    [SerializeField] bool deactivateOnCollide;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag=="player"){
        other.GetComponent<Character>()?.TakeDamage(this);
        print("hit");
        }
        else if (other.gameObject.tag=="enemy"){
        other.GetComponent<EnemyCharacter>()?.TakeDamage(this);
        gameObject.SetActive(!deactivateOnCollide);
        }
    }
}
