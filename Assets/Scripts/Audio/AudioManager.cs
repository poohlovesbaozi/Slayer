
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("监听")]
    public PlayAudioEventSO FXEvent;
    public PlayAudioEventSO BGMEvent;
    [SerializeField] VoidEventSO pauseEvent;
    [SerializeField] FloatEventSO VolumeChangeEvent;
    [Header("广播")]
    [SerializeField] FloatEventSO syncVolumeEvent;
    [Header("组件")]
    [SerializeField] AudioSource FXSource;
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioMixer mixer;
    private void OnEnable() {
        FXEvent.OnEventRaised+=OnFXEvent;
        BGMEvent.OnEventRaised+=OnBGMEvent;
        VolumeChangeEvent.OnEventRaised+=ChangeVolume;
        pauseEvent.OnEventRaised+=OnPauseEvent;
    }
    private void OnDisable() {
        FXEvent.OnEventRaised-=OnFXEvent;
        BGMEvent.OnEventRaised-=OnBGMEvent;
        VolumeChangeEvent.OnEventRaised-=ChangeVolume;
        pauseEvent.OnEventRaised-=OnPauseEvent;
    }

    private void OnPauseEvent()
    {
        //同步ui显示和音量
        float volume;
        mixer.GetFloat("masterVolume",out volume);
        syncVolumeEvent.RaiseEvent(volume);
    }

    private void ChangeVolume(float volume)
    {
        //slider value值和mixer中的volume值不一样，需要乘100再减去80
        mixer.SetFloat("masterVolume",volume*100-80);
    }

    private void OnBGMEvent(AudioClip audioClip)
    {
        BGMSource.clip=audioClip;
        BGMSource.Play();
    }

    private void OnFXEvent(AudioClip audioClip)
    {
        FXSource.clip=audioClip;
        FXSource.Play();
    }
}
