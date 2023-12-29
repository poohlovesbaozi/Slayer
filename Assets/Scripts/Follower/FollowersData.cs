using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowersData : MonoBehaviour
{
    [Header("监听")]
    [SerializeField] VoidEventSO OnNecromancerDie;
    [SerializeField] VoidEventSO OnNightBorneDie;
    [SerializeField] VoidEventSO OnEvilWizardDie;
    [SerializeField] GameObject smith;
    [SerializeField] GameObject suspicious;
    [SerializeField] GameObject hunter;
    [SerializeField] GameObject nun;
    [SerializeField] GameObject digger;
    public static List<GameObject> followers;
    private void Awake()
    {
        followers = new();
        followers.Add(smith);
    }
    private void OnEnable()
    {
        OnNecromancerDie.OnEventRaised += NecromancerDie;
        OnNightBorneDie.OnEventRaised += NightBorneDie;
        OnEvilWizardDie.OnEventRaised += EvilWizardDie;
    }
    private void OnDisable()
    {
        OnNecromancerDie.OnEventRaised -= NecromancerDie;
        OnNightBorneDie.OnEventRaised -= NightBorneDie;
        OnEvilWizardDie.OnEventRaised -= EvilWizardDie;
    }

    private void NecromancerDie()
    {
        suspicious.SetActive(true);
        if (!followers.Contains(suspicious))
            followers.Add(suspicious);
    }
    private void NightBorneDie()
    {
        hunter.SetActive(true);
        if (!followers.Contains(hunter))
            followers.Add(hunter);
    }
    private void EvilWizardDie()
    {
        digger.SetActive(true);
        if (!followers.Contains(digger))
        {
            followers.Add(digger);
        }
    }
    private void Level_4BossDie()
    {
        nun.SetActive(true);
        if (!followers.Contains(nun))
        {
            followers.Add(nun);
        }
    }

}
