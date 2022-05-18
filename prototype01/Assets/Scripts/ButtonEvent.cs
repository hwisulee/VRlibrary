using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using SimpleWebBrowser;
using System;

public class ButtonEvent : MonoBehaviour
{
    [Header("Button")]
    public GameObject Selectbutton;
    public GameObject Settingbutton;
    public GameObject Menuoutbutton;
    public GameObject Quitbutton;

    [Header("Panel")]
    public GameObject SelectPanel;
    public GameObject SettingPanel;
    public GameObject QuitPanel;

    [Header("Canvas")]
    public GameObject WebBrowser;
    public GameObject UI;

    private bool IsVisible;
    private string ClickCheck;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void SelectBtn()
    {
        ClickCheck = EventSystem.current.currentSelectedGameObject.name;

        if (IsVisible == false)
        {
            IsVisible = true;
            SelectPanel.SetActive(true);
        }
        else if (ClickCheck == "ButtonW1")
        {
            MenuOutBtn();
            SceneManager.LoadScene("Child_Library");
        }
        else if (ClickCheck == "ButtonW2")
        {
            MenuOutBtn();
            SceneManager.LoadScene("Library1");
        }
        else if (ClickCheck == "ButtonW3")
        {
            MenuOutBtn();
            SceneManager.LoadScene("Cafe");
        }
        else if (ClickCheck == "BackButton")
        {
            IsVisible = false;
            SelectPanel.SetActive(false);
        }
    }

    public void SettingBtn()
    {
        ClickCheck = EventSystem.current.currentSelectedGameObject.name;

        if (IsVisible == false)
        {
            IsVisible = true;
            SettingPanel.SetActive(true);
        }
        else if (ClickCheck == "BackButton")
        {
            IsVisible = false;
            SettingPanel.SetActive(false);
        }
    }

    public void MenuOutBtn()
    {
        FirstPersonController.isInteracting = false;
        StarterAssetsInputs.SetCursorState(true);
        UI.SetActive(false);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
