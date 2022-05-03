using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private CarInfoPanel   _carInfoPanel;
    [SerializeField] private Button         _openCarInfoButton;
    [SerializeField] private Button         _closeCarInfoButton;
    [SerializeField] private HornButton     _hornButton;
    [SerializeField] private EngineToggle   _engineToggle;
    [SerializeField] private CarSoundManager _carSoundManager;

    [SerializeField] private TextMeshProUGUI _carNameText;


    private bool    _isInit = false;

    [ContextMenu("Test/Init")]
    private void Init()
    {
       
        _openCarInfoButton.onClick.AddListener(() =>
        {
            _hornButton.gameObject.SetActive(false);
            _engineToggle.gameObject.SetActive(false);
            _carInfoPanel.Show();
        });

        _closeCarInfoButton.onClick.AddListener(() =>
        {
            _carInfoPanel.Hide();
            _hornButton.gameObject.SetActive(true);
            _engineToggle.gameObject.SetActive(true);
        });

        _engineToggle.Init();

        _carSoundManager.Init(_engineToggle, _hornButton);

        _isInit = true;
    }

    [ContextMenu("Test/Show")]
    public void Show()
    {
        if (!_isInit)
            Init();

        var info = Resources.Load<CarsLibrarySO>("Cars").GetCarInfo("qr1");

        _carSoundManager.SetCarInfo(info);

        _carInfoPanel.Hide();
        _carInfoPanel.SetInfo(info);
        _carNameText.text = info.name;

        gameObject.SetActive(true);
    }

    public void Show(CarInfo info)
    {
        if (!_isInit)
            Init();

        _carSoundManager.SetCarInfo(info);

        _carInfoPanel.Hide();
        _carInfoPanel.SetInfo(info);
        _carNameText.text = info.name;

        _engineToggle.ActiveEngine(false);

        gameObject.SetActive(true);
    }

    [ContextMenu("Test/Hide")]
    public void Hide()
    {
        if (!_isInit)
            Init();

        _engineToggle.ActiveEngine(false);
        _carInfoPanel.Hide();
        gameObject.SetActive(false);
    }


}