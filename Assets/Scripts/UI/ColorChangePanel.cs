using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ColorChangePanel : MonoBehaviour
{
    [SerializeField] private Material _mainMaterial;
    [SerializeField] private Button _setColorButton;
    [SerializeField] private Image _colorImage;
    [SerializeField] private SliderColor _redSlider;
    [SerializeField] private SliderColor _greenSlider;
    [SerializeField] private SliderColor _blueSlider;

    private bool _isInit = false;

    private void Init()
    {
        _setColorButton.onClick.AddListener(() =>
        {
            var color = new Color(_redSlider.Value, _greenSlider.Value, _blueSlider.Value);
            _mainMaterial.color = color;
        });

        _redSlider.ValueChanged += SliderChanged;
        _greenSlider.ValueChanged += SliderChanged;
        _blueSlider.ValueChanged += SliderChanged;


        var color = _mainMaterial.color;
        _colorImage.color = color;
        _redSlider.Init(color.r);
        _greenSlider.Init(color.g);
        _blueSlider.Init(color.b);

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

    private void SliderChanged()
    {
        _colorImage.color = new Color(_redSlider.Value, _greenSlider.Value, _blueSlider.Value);
    }
}
