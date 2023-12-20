
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject player;
    [Header("监听")]
    [SerializeField] SceneLoadEventSO loadEvent;
    [SerializeField] FadeEventSO fadeEvent;
    [SerializeField] VoidEventSO newGameEvent;
    [SerializeField] VoidEventSO backToMenuEvent;
    [Header("位置")]
    Vector3 posToGo;
    [SerializeField] Vector3 menuPosition;
    [SerializeField] Vector3 firstPosition;
    [Header("场景")]

    [SerializeField] GameSceneSO menuScene;
    [SerializeField] GameSceneSO firstLoadScene;
    GameSceneSO currentLoadedScene;
    GameSceneSO sceneToLoad;
    [SerializeField] Transform playerTrans;
    bool fade;
    [SerializeField] float fadeDuration;
    private void Awake()
    {
        // currentLoadedScene = firstLoadScene;
        // currentLoadedScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }
    private void Start()
    {
        loadEvent.RaiseLoadRequestEvent(menuScene, menuPosition, true);
        // NewGame();
    }
    public void Reset(){
        SceneManager.LoadSceneAsync(0,LoadSceneMode.Additive);
    }
    private void OnEnable()
    {
        loadEvent.loadRequestEvent += OnLoadRequestEvent;
        newGameEvent.OnEventRaised += NewGame;
    }
    private void OnDisable()
    {
        loadEvent.loadRequestEvent -= OnLoadRequestEvent;
        newGameEvent.OnEventRaised -= NewGame;
    }

    void NewGame()
    {
        sceneToLoad = firstLoadScene;
        loadEvent.RaiseLoadRequestEvent(sceneToLoad, firstPosition, true);
    }
    private void OnLoadRequestEvent(GameSceneSO sceneToLoad, Vector3 posToGo, bool fade)
    {
        this.sceneToLoad = sceneToLoad;
        this.posToGo = posToGo;
        this.fade = fade;
        if (currentLoadedScene != null)
        {
            StartCoroutine(UnLoadPreviousScene());
        }
        else
        {
            LoadNewScene();
        }
    }
    IEnumerator UnLoadPreviousScene()
    {
        if (fade)
        {
            // TODO fade screen
            fadeEvent.FadeIn(fadeDuration);
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
        playerTrans.position = posToGo;
        foreach (var follower in FollowersData.followers)
        {
            follower.transform.position = posToGo;
        }
        if (fade)
        {
            //TODO
            fadeEvent.FadeOut(fadeDuration);
        }
    }
}
