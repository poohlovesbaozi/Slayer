using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GemCount : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public void OnGemChange(int gems)
    {
        text.SetText(gems.ToString());
    }
}
