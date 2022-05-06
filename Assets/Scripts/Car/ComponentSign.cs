using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ComponentSign : MonoBehaviour
{
    public event Action Hold;
    public event Action Click;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _actionText;

    private ICarComponent _carComponent;
    private Transform _lookTarget;

    public void Init(Transform lookTarget, ICarComponent carComponent)
    {
        _lookTarget = lookTarget;
        _carComponent = carComponent;
        var info = _carComponent.Info;
        _nameText.text = info.Name;
        _descriptionText.text = info.Description;
        _actionText.text = info.ActionText;
    }

    private void Update()
    {
        transform.LookAt(_lookTarget);
    }

    private void OnMouseDrag()
    {
        Hold?.Invoke();
    }

    private void OnMouseDown()
    {
        Click?.Invoke();
    }
}
