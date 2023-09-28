using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("监听")]
    public PlayAudioEventSO FXEvent;
    public PlayAudioEventSO BGMEvent;
    [SerializeField] AudioSource FXSource;
    [SerializeField] AudioSource BGMSource;
    private void OnEnable() {
        FXEvent.OnEventRaised+=OnFXEvent;
    }
    private void OnDisable() {
        FXEvent.OnEventRaised-=OnFXEvent;
    }

    private void OnFXEvent(AudioClip audioClip)
    {
        FXSource.clip=audioClip;
        FXSource.Play();
    }
}
