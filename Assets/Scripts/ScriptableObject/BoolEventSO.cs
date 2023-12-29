using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/BoolEvent")]
public class BoolEventSO : ScriptableObject
{
     public UnityAction<bool> OnEventRaised;
    public void RaiseEvent(bool value)
    {
        OnEventRaised?.Invoke(value);
    }
}
