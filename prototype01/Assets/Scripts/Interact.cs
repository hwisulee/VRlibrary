using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private StarterAssetsInputs _input;

    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "감지 시작");
    }

    public void OnTriggerStay(Collider other)
    {
        HUD.IsVisible = true;

        // 충돌이 진행되는 동안 매 프레임마다 호출
        if (other.gameObject.tag == "Player")
        {
            if (_input.action == true)
            {
                FirstPersonController.isInteracting = true;
                HUD.IsVisible = false;
                StarterAssetsInputs.SetCursorState(false);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + "감지 종료");
        HUD.IsVisible = false;
    }
}
