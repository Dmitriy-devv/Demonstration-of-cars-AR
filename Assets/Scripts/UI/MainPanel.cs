using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainPanel : MonoBehaviour
{
    public event Action MenuButton;

    [SerializeField] private Button _menuButton;

    private bool _isInit = false;

    private void Init()
    {
        _menuButton.onClick.AddListener(() => SceneLoader.LoadScene(Scene.Menu));

        _isInit = true;
    }

    public void Show()
    {
        if (!_isInit)
            Init();

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    
}
