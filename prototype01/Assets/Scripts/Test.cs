using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private ImageLoader imageLoader;
    private PDFLoader pdfLoader;
    private FileBrowserForUser fbfu;

    public GameObject ChangeButton;
    public GameObject ExitButton;

    private string ClickCheck;
    private bool viewerSwitch;

    public void OnLoad()
    {
        if (viewerSwitch == false)
        {
            viewerSwitch = true;
        }
        else
        {
            viewerSwitch = false;

            OnLoad();
        }
    }

    public void StopLoad()
    {
        viewerSwitch = false;
    }

    public void OnClick()
    {
        ClickCheck = EventSystem.current.currentSelectedGameObject.name;

        if (ClickCheck == "ChangeButton")
        {
            fbfu.OnClick();
        }
        else if (ClickCheck == "ExitButton")
        {
            StopLoad();
        }
    }
}
