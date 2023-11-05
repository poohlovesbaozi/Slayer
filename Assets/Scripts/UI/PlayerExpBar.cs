using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerExpBar : MonoBehaviour
{
    [SerializeField] Image expFillImage;
    [SerializeField] TMP_Text levelText;
    public void OnExpChange(float percentage)
    {
        expFillImage.fillAmount = percentage;
    }
    public void OnLevelChange(int level)
    {
        levelText.SetText("Level:"+level);
    }

}
