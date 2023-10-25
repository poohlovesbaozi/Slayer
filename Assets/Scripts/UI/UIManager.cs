using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("组件")]
    [SerializeField] Canvas mainCanvas;
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
        // settingsButton.onClick.AddListener(TogglePausePanel);
    }
    private void OnEnable()
    {
        healthEvent.OnEventRaised += OnHealthEvent;
        gemEvent.OnEventRaised += OnGemChange;
        loadEvent.loadRequestEvent += OnLoadEvent;
        syncVolumeEvent.OnEventRaised += OnSyncVolumeEvent;
    }
    private void OnDisable()
    {
        healthEvent.OnEventRaised -= OnHealthEvent;
        gemEvent.OnEventRaised -= OnGemChange;
        loadEvent.loadRequestEvent -= OnLoadEvent;
        syncVolumeEvent.OnEventRaised -= OnSyncVolumeEvent;
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void TogglePanel(GameObject panel){
        if (panel.activeInHierarchy){
            panel.SetActive(false);
        }
        else{
            panel.SetActive(true);
        }
    }

    private void OnSyncVolumeEvent(float volume)
    {
        //slider的value和mixer的volume不一致
        masterVolumeSlider.value = (volume + 80) / 100;
    }

    private void OnLoadEvent(GameSceneSO scene, Vector3 arg1, bool arg2)
    {
        //直接判断是否是menu，决定是否启用玩家ui
        var isMenu = scene.sceneType == SceneType.Menu;
        playerHealthBar.gameObject?.SetActive(!isMenu);
        gemCount.gameObject?.SetActive(!isMenu);
    }
    public void TogglePausePanel()
    {
        if (pausePanel.activeInHierarchy)
        {
            mainCanvas.sortingOrder = 0;
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            mainCanvas.sortingOrder = 50;
            pauseEvent.RaiseEvent();
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnHealthEvent(Character character)
    {
        float percentage = character.stats.CurrentHp / character.stats.MaxHp;
        character.GetComponentInChildren<PlayerHealthBar>().OnHealthChange(percentage);

    }
    void OnGemChange(Character character)
    {
        gemCount.OnGemChange(character.stats.AzureGem);
    }
}
