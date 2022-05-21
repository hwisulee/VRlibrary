using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleFileBrowser;
using UnityEngine.UI;
using Paroxe.PdfRenderer;

public class FileBrowserForUser : MonoBehaviour
{
    private TextLoader textLoader;
    private ImageLoader imageLoader;
    private PDFViewer pdfViewer;
    private PDFLoader pdfLoader;
    private Test test;

    public string Switch = "1";
    public string Temp = "1";

    private void Awake()
    {
        textLoader = GetComponent<TextLoader>();
        imageLoader = GetComponent<ImageLoader>();
        pdfViewer = GetComponent<PDFViewer>();
        pdfLoader = GetComponent<PDFLoader>();
        test = GetComponent<Test>();
    }

    public void OnClick()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"), new FileBrowser.Filter("Texts", ".txt", ".pdf", ".csv"));
        //FileBrowser.SetDefaultFilter("");
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);

        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load");
        Debug.Log(FileBrowser.Success + ", " + FileBrowser.Result);

        if (FileBrowser.Success)
        {
            for (int i = 0; i < FileBrowser.Result.Length; i++)
            {
                Debug.Log(FileBrowser.Result[i]);
            }

            //byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);

            //string destinationPath = Path.Combine(Application.persistentDataPath, FileBrowserHelpers.GetFilename(FileBrowser.Result[0]));
            //FileBrowserHelpers.CopyFile(FileBrowser.Result[0], destinationPath);

            string extension = FileBrowser.Result[0];
            extension = extension.Substring(extension.Length - 4);

            Debug.LogError(FileBrowser.Result[0]);
            Debug.LogError(extension);

            if (extension == ".txt" || extension == ".TXT")
            {
                Switch = "1";
                SwitchChecker();
            }
            else if (extension == ".pdf" || extension == ".PDF")
            {
                Switch = "2";
                SwitchChecker();
            }
            else if (extension == ".png" || extension == ".jpg" || extension == ".PNG" || extension == ".JPG")
            {
                Switch = "3";
                SwitchChecker();
            }
            else if (extension == ".csv" || extension == ".CSV")
            {
                Switch = "4";
                SwitchChecker();
            }
        }
    }

    public void SwitchChecker()
    {
        // Temp의 기본값 = "1" ...... 1 = Text, 2 = PDF, 3 = Image

        while(true)
        {
            if (Switch == "1") // If Selected Text...
            {
                if (Switch != Temp)
                {
                    if (Temp == "2")
                    {
                        pdfLoader.StopLoad();
                        Temp = Switch;
                    }

                    else if (Temp == "3")
                    {
                        imageLoader.StopLoad();
                        Temp = Switch;
                    }
                }
                else
                {
                    textLoader.OnLoad(FileBrowser.Result[0]);
                    Debug.Log("txt");
                    test.OnLoad();
                    Temp = Switch;
                    break;
                }
            }
            else if (Switch == "2") // If Selected PDF...
            {
                if (Switch != Temp)
                {
                    if (Temp == "1")
                    {
                        textLoader.StopLoad();
                        Temp = Switch;
                    }

                    else if (Temp == "3")
                    {
                        imageLoader.StopLoad();
                        Temp = Switch;
                    }
                }
                else
                {
                    Debug.Log("pdf");
                    pdfLoader.OnLoad();
                    test.OnLoad();
                    Temp = Switch;
                    break;
                }
            }
            else if (Switch == "3") // If Selected Image...
            {
                if (Switch != Temp)
                {
                    if (Temp == "1")
                    {
                        textLoader.StopLoad();
                        Temp = Switch;
                    }

                    else if (Temp == "2")
                    {
                        pdfLoader.StopLoad();
                        Temp = Switch;
                    }
                }
                else
                {
                    Debug.Log("png or jpg");
                    imageLoader.OnLoad();
                    test.OnLoad();
                    Temp = Switch;
                    break;
                }
            }
        }
    }
}
