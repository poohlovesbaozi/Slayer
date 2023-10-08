
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [Header("监听")]
    [SerializeField] SceneLoadEventSO loadEvent;
    [SerializeField] GameSceneSO firstLoadScene;
    [SerializeField] Transform playerTrans;
    GameSceneSO currentLoadedScene;
    GameSceneSO sceneToLoad;
    Vector3 posToGo;
    bool fade;
    [SerializeField] float fadeDuration;
    private void Awake()
    {
        currentLoadedScene = firstLoadScene;
        currentLoadedScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }
    private void OnEnable()
    {
        loadEvent.loadRequestEvent += OnLoadRequestEvent;
    }
    private void OnDisable()
    {
        loadEvent.loadRequestEvent -= OnLoadRequestEvent;
    }

    private void OnLoadRequestEvent(GameSceneSO sceneToLoad, Vector3 posToGo, bool fade)
    {
        this.sceneToLoad = sceneToLoad;
        this.posToGo = posToGo;
        this.fade = fade;
        if (currentLoadedScene != null)
            StartCoroutine(UnLoadPreviousScene());
    }
    IEnumerator UnLoadPreviousScene()
    {
        if (fade)
        {
            // TODO fade screen
        }
        yield return new WaitForSeconds(fadeDuration);
        yield return currentLoadedScene.sceneReference.UnLoadScene();
        LoadNewScene();
    }
    void LoadNewScene()
    {
        var loadOperation = sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        loadOperation.Completed += OnLoadingCompleted;
    }
    /// <summary>
    /// 场景加载结束后
    /// </summary>
    /// <param name="handle"></param>

    private void OnLoadingCompleted(AsyncOperationHandle<SceneInstance> handle)
    {
        //场景加载完成后，当前加载的场景就是之前将要加载的场景
        currentLoadedScene = sceneToLoad;
        playerTrans.position=posToGo;
        if (fade)
        {
            //TODO
        }
    }
}
