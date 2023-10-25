using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Image greenHealthImage;
    [SerializeField] Transform playerTrans;

    private void Update()
    {
            transform.localScale=new Vector3(playerTrans.localScale.x,1,1);
    }

    /// <summary>
    /// accept hp percentage to change the health bar image.
    /// </summary>
    /// <param name="percentage"></param> <summary>
    public void OnHealthChange(float percentage)
    {
        greenHealthImage.fillAmount = percentage;
        Debug.Log(percentage);
    }
}
