using Paroxe.PdfRenderer;
using System.Collections;
using System.Collections.Generic;
using SimpleFileBrowser;
using UnityEngine;
using UnityEditor;

public class PDFLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject PDFViewer;

    private PDFViewer pdfViewer;
    private string path = "";
    private bool viewerSwitch;

    public void Awake()
    {
        pdfViewer = GetComponent<PDFViewer>();

        PDFViewer.SetActive(false);
    }

    public void OnLoad()
    {
        Paroxe.PdfRenderer.PDFViewer.m_FilePath = FileBrowser.Result[0];

        if (viewerSwitch == false)
        {
            PDFViewer.SetActive(true);
            viewerSwitch = true;
        }
        else
        {
            PDFViewer.SetActive(false);
            viewerSwitch = false;

            OnLoad();
        }
    }

    public void StopLoad()
    {
        PDFViewer.SetActive(false);
        viewerSwitch = false;
    }
}
