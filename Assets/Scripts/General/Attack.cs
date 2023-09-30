using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    [SerializeField] bool deactivateOnCollide;
    private void OnTriggerStay2D(Collider2D other) {
        other.GetComponent<Character>()?.TakeDamage(this);
        if (deactivateOnCollide)
        gameObject.SetActive(false);
    }
}
