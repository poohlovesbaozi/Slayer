using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowersData : MonoBehaviour
{
    [SerializeField] VoidEventSO OnNecromancerDie;
    [SerializeField] GameObject suspicious;
    public static List<GameObject> followers;
    private void Awake()
    {
        followers = new();
    }
    private void OnEnable()
    {
        OnNecromancerDie.OnEventRaised += NecromancerDie;
    }
    private void OnDisable()
    {
        OnNecromancerDie.OnEventRaised -= NecromancerDie;
    }

    private void NecromancerDie()
    {
        suspicious.SetActive(true);
        if (!followers.Contains(suspicious))
            followers.Add(suspicious);
    }
}
