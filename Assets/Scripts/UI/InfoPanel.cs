using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InfoPanel : MonoBehaviour
{
    
    [SerializeField] private CarInfoPanel       _carInfoPanel;
    [SerializeField] private ColorChangePanel   _colorChangePanel;
    [SerializeField] private Button             _openCarInfoButton;
    [SerializeField] private Button             _closeCarInfoButton;
    [SerializeField] private Button             _openColorButton;
    [SerializeField] private Button             _closeColorButton;

    [SerializeField] private TextMeshProUGUI _carNameText;

    private bool    _isInit = false;

    private void Init()
    {
       
        _openCarInfoButton.onClick.AddListener(() =>
        {
            _carInfoPanel.Show();
        });

        _closeCarInfoButton.onClick.AddListener(() =>
        {
            _carInfoPanel.Hide();
        });

        _openColorButton.onClick.AddListener(() =>
        {
            _colorChangePanel.Show();
        });

        _closeColorButton.onClick.AddListener(() =>
        {
            _colorChangePanel.Hide();
        });


        _isInit = true;
    }

    public void Show(CarInfo info)
    {
        if (!_isInit)
            Init();

        _carInfoPanel.Hide();
        _colorChangePanel.Hide();
        _carInfoPanel.SetInfo(info);
        _carNameText.text = info.name;

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        if (!_isInit)
            Init();

        _carInfoPanel.Hide();
        _colorChangePanel.Hide();
        gameObject.SetActive(false);
    }

}
