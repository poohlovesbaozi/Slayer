using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDefinition : MonoBehaviour
{
    [SerializeField] PlayAudioEventSO playAudioEvent;
    [SerializeField] AudioClip audioClip;
    [SerializeField] bool playOnEnable;
    [SerializeField] bool playOnDisable;
    private void OnEnable() {
    if (playOnEnable){
        PlayAudioClip();
    }    
    }
    private void OnDisable() {
        if (playOnDisable){
            PlayAudioClip();
        }
    }

    private void PlayAudioClip()
    {
        playAudioEvent.OnEventRaised(audioClip);
    }
}
