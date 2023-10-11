using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("组件")]
    [SerializeField] Button settingsButton;
    [SerializeField] GameObject pausePanel;
    [SerializeField] PlayerHealthBar playerHealthBar;
    [SerializeField] GemCount gemCount;
    [SerializeField] Slider masterVolumeSlider;
    [Header("监听")]
    [SerializeField] CharacterEventSO healthEvent;
    [SerializeField] CharacterEventSO gemEvent;
    [SerializeField] SceneLoadEventSO loadEvent;
    [SerializeField] FloatEventSO syncVolumeEvent;
    [Header("广播")]
    [SerializeField] VoidEventSO pauseEvent;
    private void Awake()
    {
        settingsButton.onClick.AddListener(TogglePausePanel);
    }
    private void OnEnable()
    {
        healthEvent.OnEventRaised += OnHealthEvent;
        gemEvent.OnEventRaised += OnGemChange;
        loadEvent.loadRequestEvent += OnLoadEvent;
        syncVolumeEvent.OnEventRaised+=OnSyncVolumeEvent;
    }
    private void OnDisable()
    {
        healthEvent.OnEventRaised -= OnHealthEvent;
        gemEvent.OnEventRaised -= OnGemChange;
        loadEvent.loadRequestEvent -= OnLoadEvent;
        syncVolumeEvent.OnEventRaised-=OnSyncVolumeEvent;
    }

    private void OnSyncVolumeEvent(float volume)
    {
        //slider的value和mixer的volume不一致
        masterVolumeSlider.value=(volume+80)/100;
    }

    private void OnLoadEvent(GameSceneSO scene, Vector3 arg1, bool arg2)
    {
        //直接判断是否是menu，决定是否启用玩家ui
        var isMenu = scene.sceneType == SceneType.Menu;
        playerHealthBar.gameObject?.SetActive(!isMenu);
        gemCount.gameObject?.SetActive(!isMenu);
    }
    void TogglePausePanel()
    {
        if (pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseEvent.RaiseEvent();
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnHealthEvent(Character character)
    {
        float percentage = character.hp / character.maxHp;
        character.GetComponentInChildren<PlayerHealthBar>().OnHealthChange(percentage);

    }
    void OnGemChange(Character character)
    {
        gemCount.OnGemChange(character.azureGem);
    }
}
