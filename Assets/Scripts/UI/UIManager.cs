using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerHealthBar playerHealthBar;
    [SerializeField] GemCount gemCount;
    [Header("监听")]
    [SerializeField] CharacterEventSO healthEvent;
    [SerializeField] CharacterEventSO gemEvent;
    private void OnEnable()
    {
        healthEvent.OnEventRaised += OnHealthEvent;
        gemEvent.OnEventRaised+=OnGemChange;
    }
    private void OnDisable()
    {
        healthEvent.OnEventRaised += OnHealthEvent;
        gemEvent.OnEventRaised-=OnGemChange;
    }

    private void OnHealthEvent(Character character)
    {
        float percentage=character.hp/character.maxHp;
        playerHealthBar.OnHealthChange(percentage);
    }
    void OnGemChange(Character character){
        gemCount.OnGemChange(character.azureGem);
    }
}
