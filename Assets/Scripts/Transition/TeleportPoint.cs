using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour, IInteractable
{
    [SerializeField] Vector3 positionToGo;
    [SerializeField] GameSceneSO sceneToGo;
    [SerializeField] SceneLoadEventSO loadEvent;
    Animator anim;
    public bool canInteract;
    private void Awake()
    {
        anim=GetComponent<Animator>();
        canInteract = false;
    }
    public void Activate()
    {
        canInteract=true;
        anim.SetBool("canInteract", canInteract);
    }
    public void TriggerAction()
    {
        loadEvent?.RaiseLoadRequestEvent(sceneToGo, positionToGo, true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canInteract)
        {
            TriggerAction();
        }
    }
}
