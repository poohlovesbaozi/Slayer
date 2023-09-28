using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDefinition : MonoBehaviour
{
    [SerializeField] PlayAudioEventSO playAudioEvent;
    [SerializeField] AudioClip audioClip;
    [SerializeField] bool playOnEnable;
    private void OnEnable() {
    if (playOnEnable){
        PlayAudioClip();
    }    
    }

    private void PlayAudioClip()
    {
        playAudioEvent.OnEventRaised(audioClip);
    }
}
