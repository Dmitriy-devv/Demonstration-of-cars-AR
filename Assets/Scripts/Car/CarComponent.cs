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
        _currentSign.Click += OnUIClick;
        _currentSign.Hold += OnUIHold;
    }

    private void OnUIHold()
    {
        Debug.Log($"{name} holded by UI");
    }

    private void OnUIClick()
    {
        Debug.Log($"{name} clicked by UI");
    }
}
