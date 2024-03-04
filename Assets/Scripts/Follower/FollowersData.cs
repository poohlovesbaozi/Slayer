using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowersData : MonoBehaviour
{
    [Header("监听")]
    [SerializeField] VoidEventSO OnNecromancerDie;
    [SerializeField] VoidEventSO OnNightBorneDie;
    [SerializeField] VoidEventSO OnSkeletonDie;
    [SerializeField] VoidEventSO OnEvilWizardDie;
    [SerializeField] GameObject smith;
    [SerializeField] GameObject suspicious;
    [SerializeField] GameObject hunter;
    [SerializeField] GameObject nun;
    [SerializeField] GameObject digger;
    [SerializeField] public static List<GameObject> followers;
    private void Awake()
    {
        followers = new();
        followers.Add(smith);
        print(followers[0].name);
    }
    private void OnEnable()
    {
        OnNecromancerDie.OnEventRaised += Level_1BossDie;
        OnNightBorneDie.OnEventRaised += Level_2BossDie;
        OnSkeletonDie.OnEventRaised += Level_3BossDie;
        OnEvilWizardDie.OnEventRaised += Level_4BossDie;
    }
    private void OnDisable()
    {
        OnNecromancerDie.OnEventRaised -= Level_1BossDie;
        OnNightBorneDie.OnEventRaised -= Level_2BossDie;
        OnSkeletonDie.OnEventRaised -= Level_3BossDie;
        OnEvilWizardDie.OnEventRaised -= Level_4BossDie;
    }

    private void Level_1BossDie()
    {
        if (!followers.Contains(suspicious))
        {
            suspicious.SetActive(true);
            followers.Add(suspicious);
            print(followers[1].name);
        }
    }
    private void Level_2BossDie()
    {
        if (!followers.Contains(digger))
        {
            digger.SetActive(true);
            followers.Add(digger);
            print(followers[2].name);
        }
    }
    private void Level_3BossDie()
    {
        if (!followers.Contains(hunter))
        {
            hunter.SetActive(true);
            followers.Add(hunter);
            print(followers[3].name);
        }
    }
    private void Level_4BossDie()
    {
        if (!followers.Contains(nun))
        {
            nun.SetActive(true);
            followers.Add(nun);
            print(followers[4].name);
        }
    }

}
