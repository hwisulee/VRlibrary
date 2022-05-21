using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject ImageViewer;

    [SerializeField]
    private Image ImageDrawTexture;

    private float maxWidth = 1088;
    private float maxHeight = 682;
    private bool viewerSwitch;

    public void Awake()
    {
        ImageViewer.SetActive(false);
    }

    public void OnLoad()
    {
        if (viewerSwitch == false)
        {
            ImageViewer.SetActive(true);
            viewerSwitch = true;

            byte[] byteTexture = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);

            Texture2D texture2D = new Texture2D(0, 0);
            if (byteTexture.Length > 0)
            {
                texture2D.LoadImage(byteTexture);
            }

            if (texture2D.width > maxWidth)
            {
                ImageDrawTexture.rectTransform.sizeDelta = new Vector2(maxWidth, maxWidth / texture2D.width * texture2D.height);
            }
            else if (texture2D.height > maxHeight)
            {
                ImageDrawTexture.rectTransform.sizeDelta = new Vector2(maxHeight / texture2D.height * texture2D.width, maxHeight);
            }
            else
            {
                ImageDrawTexture.rectTransform.sizeDelta = new Vector2(texture2D.width, texture2D.height);
            }

            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 05f));
            ImageDrawTexture.sprite = sprite;
        }
        else
        {
            ImageViewer.SetActive(false);
            viewerSwitch = false;

            OnLoad();
        }
        
    }

    public void StopLoad()
    {
        ImageViewer.SetActive(false);
        viewerSwitch = false;
    }
}
