using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Image greenHealthImage;

    /// <summary>
    /// accept hp percentage to change the health bar image.
    /// </summary>
    /// <param name="percentage"></param> <summary>
    public void OnHealthChange(float percentage)
    {
        greenHealthImage.fillAmount = percentage;
    }
}