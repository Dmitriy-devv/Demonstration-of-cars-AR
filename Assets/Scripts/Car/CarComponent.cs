using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComponent : MonoBehaviour, IRaycastable, ICarComponent
{
    public ComponentInfo Info => _info;

    [SerializeField] private ComponentInfo _info;

    private ComponentSign _signPrefab;
    private ComponentSign _currentSign;

    public void Init(ComponentSign sign)
    {
        _signPrefab = sign;
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

        var position = transform.position + Vector3.up;
        _currentSign = Instantiate(_signPrefab, position, Quaternion.identity);
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
