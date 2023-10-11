using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject newGameButton;
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(newGameButton);
    }
    public void ExitGame(){
        print("quit");
        Application.Quit();
    }
}
