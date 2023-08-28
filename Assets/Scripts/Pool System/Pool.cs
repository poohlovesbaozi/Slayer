using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public GameObject Prefab => prefab;
    public int Size=>size;
    public int RuntimeSize=>queue.Count;

    [SerializeField] GameObject prefab;
    [SerializeField] int size = 1;
    Queue<GameObject> queue;
    Transform parent;
    #region 生成备用对象
    public void Initialize(Transform parent)
    {
        this.parent = parent;
        queue = new();
        for (int i = 1; i < size; i++)
        {
            queue.Enqueue(Copy());
        }
    }
    GameObject Copy()
    {
        var copy = GameObject.Instantiate(prefab, parent);
        copy.SetActive(false);
        return copy;
    }
    #endregion
    GameObject AvailableObject()
    {
        GameObject availableObject = null;
        if (queue.Count > 0 && !queue.Peek().activeSelf)
        {
            availableObject = queue.Dequeue();
        }
        else
        {
            availableObject = Copy();
        }
        //提前将物体放回队列
        queue.Enqueue(availableObject);
        return availableObject;
    }
    /// <summary>
    /// 启用制作好的对象
    /// </summary>
    /// <param name="shootDir"></param>
    public GameObject PreparedObeject(Vector2 shootDir)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.GetComponent<Projectile>().shootDir = shootDir;
        return preparedObject;
    }
    public GameObject PreparedObeject(Vector2 shootDir,Vector3 position)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.GetComponent<Projectile>().shootDir = shootDir;
        preparedObject.transform.position = position;
        return preparedObject;
    }

    public GameObject PreparedObeject(Vector2 shootDir,Vector3 position, Quaternion rotation)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.GetComponent<Projectile>().shootDir = shootDir;
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;
        return preparedObject;
    }
    public GameObject PreparedObeject(Vector2 shootDir,Vector3 position, Quaternion rotation, Vector3 localScale)
    {
        GameObject preparedObject = AvailableObject();
        preparedObject.SetActive(true);
        preparedObject.GetComponent<Projectile>().shootDir = shootDir;
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;
        preparedObject.transform.localScale = localScale;
        return preparedObject;
    }

}
