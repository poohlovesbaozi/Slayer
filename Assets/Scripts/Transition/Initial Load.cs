using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class InitialLoad : MonoBehaviour
{
    [SerializeField] AssetReference persistentScene;
    private void Awake()
    {
        Addressables.LoadSceneAsync(persistentScene);
    }
}
