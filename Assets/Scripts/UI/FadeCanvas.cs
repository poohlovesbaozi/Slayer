using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class FadeCanvas : MonoBehaviour
{
    [Header("监听")]
    [SerializeField] FadeEventSO fadeEvent;
    [SerializeField] Image fadeImage;
    private void OnEnable() {
        fadeEvent.OnEventRaised+=OnFadeEvent;
    }
    private void OnDisable() {
        fadeEvent.OnEventRaised-=OnFadeEvent;
    }

    void OnFadeEvent(Color targetColor, float duration,bool fadeIn)
    {
        fadeImage.DOBlendableColor(targetColor, duration);
    }
}
