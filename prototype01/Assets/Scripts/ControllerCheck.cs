using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using SimpleFileBrowser;
using StarterAssets;
using Ricimi;

public class ControllerCheck : MonoBehaviour
{
    [Header("Control Platform")]
    public GameObject KM;
    public GameObject VR;
    public GameObject PC_UI;
    public GameObject VR_UI;
    public GameObject ControllerPanel;
    public GameObject ErrorPanel;

    public GameObject btn;
    public GameObject lockbutton;

    private string ClickCheck;

    public static bool controllercheck = false;
    public static string control_platform = "pc";

    int temp = 0;

    private void Awake()
    {
        if (control_platform == "pc")
        {
            FileBrowser.VR_Check = false;
            KM.SetActive(true);
            VR.SetActive(false);
            PC_UI.SetActive(true);
            VR_UI.SetActive(false);
        }
        else if (control_platform == "vr")
        {
            FileBrowser.VR_Check = true;
            KM.SetActive(false);
            VR.SetActive(true);
            PC_UI.SetActive(false);
            VR_UI.SetActive(true);
        }
    }

    private void Start()
    {
        Debug.Log(control_platform);
        Debug.Log(controllercheck);
        Debug.Log(FileBrowser.VR_Check);

        btn.SetActive(true);
        lockbutton.SetActive(false);

        if (controllercheck == true)
        {
            ControllerPanel.SetActive(false);
        }
        else if (controllercheck == false)
        {
            ControllerPanel.SetActive(true);
        }
    }

    public void OnLoad()
    {
        ControllerPanel.SetActive(true);
    }

    public void PCCheck()
    {
        KM.SetActive(true);
        PC_UI.SetActive(true);
        VR.SetActive(false);
        VR_UI.SetActive(false);

        controllercheck = true;
        FileBrowser.VR_Check = false;
        control_platform = "pc";
        ControllerPanel.SetActive(false);
        FirstPersonController.isInteracting = false;
        StarterAssetsInputs.SetCursorState(true);
    }

    public void VRCheck()
    {
        
        Debug.LogError(ExampleUtil.isPresent());
        Debug.LogError(temp);

        if (ExampleUtil.isPresent() == true)
        {
            //btn.GetComponent<CleanButton>().onClicked.AddListener(btn.GetComponent<Popup>().Close);

            KM.SetActive(false);
            PC_UI.SetActive(false);
            VR.SetActive(true);
            VR_UI.SetActive(true);

            controllercheck = true;
            FileBrowser.VR_Check = true;
            control_platform = "vr";
            ControllerPanel.SetActive(false);
            FirstPersonController.isInteracting = false;
            StarterAssetsInputs.SetCursorState(true);
        }
        else if (ExampleUtil.isPresent() == false)
        {
            temp += 1;

            if (temp > 1)
            {
                btn.SetActive(false);
                lockbutton.SetActive(true);
            }
            else
            {
                btn.GetComponent<CleanButton>().onClicked.AddListener(btn.GetComponent<PopupOpener>().OpenPopup);
            }
        }
    }
}
