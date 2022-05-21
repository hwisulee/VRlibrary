using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject TextViewer;
    public Text Txt;

    private bool viewerSwitch;

    public void Awake()
    {
        TextViewer.SetActive(false);
    }

    public void OnLoad(string path)
    {
        if (viewerSwitch == false)
        {
            TextViewer.SetActive(true);
            viewerSwitch = true;

            FileStream Text = new FileStream(path, FileMode.Open);
            StreamReader TextStreamReader = new StreamReader(Text);
            Txt.text = TextStreamReader.ReadToEnd();
            TextStreamReader.Close();
        }
        else
        {
            viewerSwitch = false;
            TextViewer.SetActive(false);

            OnLoad(path);
        }
        
    }

    public void StopLoad()
    {
        TextViewer.SetActive(false);
        viewerSwitch = false;
    }
}
