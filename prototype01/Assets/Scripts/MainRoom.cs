using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainRoom : MonoBehaviour
{
    public GameObject MainRoomButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainRoomBtn()
    {
        SceneManager.LoadScene("Main");
    }
}
