using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Toggle))]
public class EngineToggle : MonoBehaviour
{
    public event Action<bool> OnValueChanged;

    [SerializeField] private TMPro.TextMeshProUGUI text;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color deactiveColor;
    private Toggle _toggle;

    [ContextMenu("Test/Init")]
    public void Init()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(ValueChanged);
    }

    private void ValueChanged(bool x)
    {
        text.color = x ? activeColor : deactiveColor;
        OnValueChanged?.Invoke(x);
    }

    public void ActiveEngine(bool state)
    {
        _toggle.isOn = state;
    }

}
