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

    public void Init(ComponentSign sign)
    {
        _signPrefab = sign;
        _signPosition = GetComponentInChildren<SignPosition>().transform;
        var collider = GetComponent<ComponentCollider>();
        collider.Click += OnClick;
        collider.Hold += OnHold;
    }

    public void RaycastTriger(bool value, CameraRaycaster raycaster = null)
    {
        if (!value)
        {
            if (_currentSign == null) return;

            Destroy(_currentSign.gameObject);
            return;
        }

        _currentSign = Instantiate(_signPrefab, _signPosition.position, Quaternion.identity, _signPosition.transform);
        _currentSign.Init(raycaster.transform, this);
        _currentSign.Click += OnClick;
        _currentSign.Hold += OnHold;
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
        if (_currentSign == null) return;

        Destroy(_currentSign.gameObject);
    }
}
