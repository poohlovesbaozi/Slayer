using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerExpBar : MonoBehaviour
{
   [SerializeField] Image expFillImage;
   public void OnExpChange(float percentage){
       expFillImage.fillAmount = percentage;
   }

   
}
