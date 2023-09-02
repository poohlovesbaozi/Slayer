using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerHealthBar playerHealthBar; 
    [Header("监听")]
    [SerializeField] CharacterEventSO healthEvent;
    private void OnEnable()
    {
        healthEvent.OnEventRaised += OnHealthEvent;
    }
    private void OnDisable()
    {
        healthEvent.OnEventRaised += OnHealthEvent;
    }

    private void OnHealthEvent(Character character)
    {
        float percentage=character.hp/character.maxHp;
        playerHealthBar.OnHealthChange(percentage);
    }
}
