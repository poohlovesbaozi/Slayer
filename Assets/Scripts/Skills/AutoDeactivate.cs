using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeactivate : MonoBehaviour
{
    [SerializeField] bool destroyGameObject;
    [SerializeField] float lifeTime;

    WaitForSeconds waitLifeTime;
    private void Awake() {
        waitLifeTime=new(lifeTime);
    }
    private void OnEnable() {
        StartCoroutine(DeactivateCoroutine());
    }

IEnumerator DeactivateCoroutine(){
    yield return waitLifeTime;
    if (destroyGameObject){
        Destroy(gameObject);
    }
    else{
        gameObject.SetActive(false);
    }
}
}
