using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public GameObject MessagePanel;
    public GameObject ExitPanel;

    public static bool IsVisible;
    public static bool IsTab;

    void Update()
    {
        if (IsTab == false)
        {
            if (IsVisible == true)
            {
                MessagePanel.SetActive(true);
            }
            else if (IsVisible == false)
            {
                MessagePanel.SetActive(false);
            }
        }
        else
        {
            MessagePanel.SetActive(false);
            ExitPanel.SetActive(true);
        }
        
    }

    public void Tab()
    {
        IsTab = false;
        ExitPanel.SetActive(false);
    }
}
