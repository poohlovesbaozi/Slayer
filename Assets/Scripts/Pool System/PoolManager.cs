using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] Pools;
    static Dictionary<GameObject, Pool> dict;
    private void Start()
    {
        dict = new();
        Initialize(Pools);
    }
#if UNITY_EDITOR
    private void OnDestroy()
    {
        CheckPoolSize(Pools);
    }
#endif
    void CheckPoolSize(Pool[] pools)
    {
        foreach (var pool in pools)
        {
            if (pool.RuntimeSize > pool.Size)
            {
                Debug.LogWarning(
                    string.Format("Pool:{0} has a runtime size {1} bigger than its initial size {2}!",
                    pool.Prefab.name,
                    pool.RuntimeSize,
                    pool.Size));
            }
        }
    }
    void Initialize(Pool[] pools)
    {
        foreach (var pool in pools)
        {
#if UNITY_EDITOR
            if (dict.ContainsKey(pool.Prefab))
            {
                Debug.LogError("Same prefab in multiple pools.Prefab: " + pool.Prefab.name);
                continue;
            }
#endif
            dict.Add(pool.Prefab, pool);
            Transform poolParent = new GameObject("Pool: " + pool.Prefab.name).transform;
            poolParent.parent = transform;
            pool.Initialize(poolParent);
            //创建时传入poolParent，然后将pool中的parent设为这个parent，然后在instansiate时指定此parent为所有prefab的parent。
        }
    }
    #region 释放预制体的重载
    public static GameObject Release(GameObject prefab)
    {
#if UNITY_EDITOR
        if (!dict.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
#endif
        return dict[prefab].PreparedObeject();
    }
    /// <summary>
    /// 释放池中预制好的对象池
    /// </summary>
    /// <param name="prefab"></param>
    public static GameObject Release(GameObject prefab, Vector3 position)
    {
#if UNITY_EDITOR
        if (!dict.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
#endif
        return dict[prefab].PreparedObeject(position);
    }
    /// <summary>
    /// 释放池中预制好的对象池
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="position">指定的位置</param>
    public static GameObject Release(GameObject prefab, Vector3 position,Vector2 shootDir)
    {
#if UNITY_EDITOR
        if (!dict.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
#endif
        return dict[prefab].PreparedObeject( position,shootDir);
    }
    /// <summary>
    /// 释放池中预制好的对象池
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="position">指定的位置</param>
    /// <param name="rotation">指定的旋转角度</param>
    public static GameObject Release(GameObject prefab,  Vector3 position,Vector2 shootDir, Quaternion rotation)
    {
#if UNITY_EDITOR
        if (!dict.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
#endif
        return dict[prefab].PreparedObeject(position, shootDir, rotation);
    }
    /// <summary>
    /// 释放池中预制好的对象池
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="position">指定的位置</param>
    /// <param name="rotation">指定的旋转角度</param>
    /// <param name="localScale">指定的缩放值</param>/// 
    public static GameObject Release(GameObject prefab,  Vector3 position,Vector2 shootDir, Quaternion rotation, Vector3 localScale)
    {
#if UNITY_EDITOR
        if (!dict.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
#endif
        return dict[prefab].PreparedObeject(position, shootDir, rotation, localScale);
    }
    #endregion
}
