using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebLoader : MonoBehaviour
{
    [Header("Canvas settings")]
    [SerializeField]
    public GameObject WebCanvas;

    public void OnLoad()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("WebCanvas");
        if (objs.Length > 1)
        {
            Destroy(WebCanvas);
        }

        Instantiate(WebCanvas);
    }

    public void OnStop()
    {
        Destroy(WebCanvas);
    }
}
