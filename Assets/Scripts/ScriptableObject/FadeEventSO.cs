using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/FadeEventSO")]
public class FadeEventSO : ScriptableObject
{
    public UnityAction<Color,float,bool> OnEventRaised;
    public void FadeIn(float duration)
    {
        RaiseEvent(Color.black,duration,true);
    }
    public void FadeOut(float duration)
    {
        RaiseEvent(Color.clear,duration,false);
    }
    void RaiseEvent(Color color,float duration,bool fadeIn){
        OnEventRaised?.Invoke(color,duration,fadeIn);
    }
}
