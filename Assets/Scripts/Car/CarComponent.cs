using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComponent : MonoBehaviour, IRaycastable, ICarComponent
{
    public ComponentInfo Info => _info;

    [SerializeField] private Transform _signPosition;
    [SerializeField] private ComponentInfo _info;

    private ComponentSign _signPrefab;
    private ComponentSign _currentSign;
    private ComponentLine _linePrefab;
    private ComponentLine _currentLine;

    public void Init(ComponentSign sign, ComponentLine line)
    {
        _signPrefab = sign;
        _signPosition = GetComponentInChildren<SignPosition>().transform;
        _linePrefab = line;
        var collider = GetComponent<ComponentCollider>();
        collider.Click += OnClick;
        collider.Hold += OnHold;
    }

    public void RaycastTriger(bool value, CameraRaycaster raycaster = null)
    {
        if (!value)
        {
            if (_currentSign != null) Destroy(_currentSign.gameObject);
            if (_currentLine != null) Destroy(_currentLine.gameObject);

            return;
        }

        _currentSign = Instantiate(_signPrefab, _signPosition.position, Quaternion.identity, _signPosition.transform);
        _currentSign.Init(raycaster.transform, this);
        _currentSign.Click += OnClick;
        _currentSign.Hold += OnHold;

        _currentLine = Instantiate(_linePrefab);
        _currentLine.Init(transform, _currentSign.transform);
    }

    private void OnHold()
    {
        Debug.Log($"{name} holded by UI");
    }

    private void OnClick()
    {
        Debug.Log($"{name} clicked by UI");
    }

    private void OnDestroy()
    {
        if (_currentSign != null) Destroy(_currentSign.gameObject);
        if (_currentLine != null) Destroy(_currentLine.gameObject);
    }
}
