using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject lastScelect;

    private void Start()
    {
        lastScelect = new GameObject();
    }

    private void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == null) 
        {
            EventSystem.current.SetSelectedGameObject(lastScelect);
        }
        else 
        {
            lastScelect = EventSystem.current.currentSelectedGameObject;
        }
    }

    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void UIEnable() 
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }
}
