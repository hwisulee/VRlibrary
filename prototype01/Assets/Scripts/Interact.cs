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
        Debug.Log(other.name + "���� ����");
    }

    public void OnTriggerStay(Collider other)
    {
        HUD.IsVisible = true;

        // �浹�� ����Ǵ� ���� �� �����Ӹ��� ȣ��
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
        Debug.Log(other.name + "���� ����");
        HUD.IsVisible = false;
    }
}
