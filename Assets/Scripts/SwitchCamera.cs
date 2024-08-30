using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private GameObject CloseCamera;
    [SerializeField] private GameObject OverallCamera;
    private int Manager;

    //Small Player
    [SerializeField] private PlayerController playerController;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private EnvironmentRotation rotation;

    //Big Player
    [SerializeField] private PlayerController playerController_Big;

    void Start()
    {
        if(Manager == 1)
        {
            Cam_Closeup();
        }
        else
        {
            Cam_Overall();
        }
    }

    
    public void Cam_Closeup()
    {
        Manager = 1;
        CloseCamera.SetActive(true);
        OverallCamera.SetActive(false);

        playerController.enabled = true;
        mouseLook.enabled = true;

        rotation.enabled = false;
        playerController_Big.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Cam_Overall()
    {
        Manager = 2;
        OverallCamera.SetActive(true);
        CloseCamera.SetActive(false);

        //Close-up Player controller scripts
        playerController.enabled = false;
        mouseLook.enabled = false;

        rotation.enabled = true;
        playerController_Big.enabled = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public int GetCameraIndex()
    {
        return Manager;
    }

}
