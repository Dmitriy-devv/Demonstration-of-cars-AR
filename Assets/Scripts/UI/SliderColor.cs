using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SliderColor : MonoBehaviour
{
    public event Action ValueChanged;

    public float Value => _slider.value;

    [SerializeField] private ColorChanel _colorChanel;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMPro.TextMeshProUGUI _valueText;
    [SerializeField] private Image _image;

    public void Init(float value)
    {
        _slider.value = value;
        UpdateInfo(value);
        _slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(float value)
    {
        UpdateInfo(value);
        ValueChanged?.Invoke();
    }

    private void UpdateInfo(float value)
    {
        _valueText.text = $"{(int)(value * 255f)}";
        switch (_colorChanel)
        {
            case ColorChanel.Red:
                _image.color = new Color(value, 0f, 0f);
                break;
            case ColorChanel.Green:
                _image.color = new Color(0f, value, 0f);
                break;
            case ColorChanel.Blue:
                _image.color = new Color(0f, 0f, value);
                break;
        }
    }

    private enum ColorChanel
    {
        Red,
        Green,
        Blue
    }
}
