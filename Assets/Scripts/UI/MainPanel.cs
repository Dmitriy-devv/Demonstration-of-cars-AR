using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private Button _menuButton;

    private bool _isInit = false;

    private void Init()
    {
        _menuButton.onClick.AddListener(LoadMenu);

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

    private void LoadMenu()
    {
        SceneLoader.LoadScene(Scene.Menu);
    }
}
