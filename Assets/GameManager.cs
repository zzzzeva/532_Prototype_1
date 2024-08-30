using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public SwitchCamera cameraManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cameraManager.Cam_Closeup();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cameraManager.Cam_Overall();
        }
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.Equals))
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        // Get the currently active scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
