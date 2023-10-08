using UnityEngine;
using UnityEngine.AddressableAssets;
[CreateAssetMenu(menuName = "GameScene/GameSceneSO")]
public class GameSceneSO : ScriptableObject {
    [SerializeField] SceneType sceneType;
    public AssetReference sceneReference;
}
