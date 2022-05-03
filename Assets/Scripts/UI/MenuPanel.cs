using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
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
