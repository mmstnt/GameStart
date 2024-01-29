using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject lastScelect;
    private GameObject[] allUIPages;
    private void Awake()
    {
        //讀取所有UI
        allUIPages = GameObject.FindGameObjectsWithTag("UIPages");
        foreach(GameObject page in allUIPages) 
        {
            page.SetActive(false);
        }
    }

    private void Start()
    {
        lastScelect = new GameObject();
    }

    private void Update()
    {
        //記憶最後選擇的按鈕
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SetUIPages("SaveUI");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void UIEnable() 
    {
        SetUIPages("MainUI");
    }

    public void PlayGameBack()
    {
        SetUIPages("MainUI");
    }

    //設定當前使用的UI
    private void SetUIPages(string pageName) 
    {
        foreach(GameObject page in allUIPages) 
        {
            if(pageName == page.name) 
            {
                page.SetActive(true);
            }
            else 
            {
                page.SetActive(false); 
            }
        }
        EventSystem.current.SetSelectedGameObject(GameObject.FindGameObjectWithTag("UIPagesFirstButton"));
    }
}
