using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    // [SerializeField]CharacterEventSO healthChangeEvent;
    [SerializeField] Image greenHealthImage;
    [SerializeField] Transform playerTrans;
    [SerializeField]float percentage;
    private void OnEnable() {
        // healthChangeEvent.OnEventRaised+=OnHealthChange;
    }
    private void OnDisable() {
        // healthChangeEvent.OnEventRaised-=OnHealthChange;
    }
    private void Update()
    {
            transform.localScale=new Vector3(playerTrans.localScale.x,1,1);
    }

    /// <summary>
    /// accept hp percentage to change the health bar image.
    /// </summary>
    /// <param name="percentage"></param> <summary>
    public void OnHealthChange(Character character)
    {
        percentage = (float)character.stats.CurrentHp /(float)character.stats.MaxHp;
        greenHealthImage.fillAmount = percentage;
    }
}
