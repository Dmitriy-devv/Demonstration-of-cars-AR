using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        var session = FindObjectOfType<ARSession>();
        if (session != null)
            Destroy(session);

        var sessionO = FindObjectOfType<ARSessionOrigin>();
        if (sessionO != null)
            Destroy(sessionO);

        var imageManager = FindObjectOfType<ARTrackedImageManager>();
        if (imageManager != null)
            Destroy(imageManager);

        Init();   
    }

    private void Init()
    {
        _startButton.onClick.AddListener(LoadMainScene);
        _exitButton.onClick.AddListener(ExitApp);
    }

    private void LoadMainScene()
    {
        SceneLoader.LoadScene(Scene.Main);
    }

    private void ExitApp()
    {
        Debug.LogWarning("Application quit");
        Application.Quit();
    }

}
