using UnityEngine.Events;
using UnityEngine;
[CreateAssetMenu(menuName = "Event/SceneLoadEvent")]
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, Vector3, bool> loadRequestEvent;
    /// <summary>
    /// 场景加载请求
    /// </summary>
    /// <param name="sceneToLoad">要加载的场景</param>
    /// <param name="posToGo">要传送的坐标</param>
    /// <param name="fade"></param> 是否有渐入渐出效果<summary>
    public void RaiseLoadRequestEvent(GameSceneSO sceneToLoad, Vector3 posToGo, bool fade)
    {
        loadRequestEvent?.Invoke(sceneToLoad, posToGo, fade);
    }
}
