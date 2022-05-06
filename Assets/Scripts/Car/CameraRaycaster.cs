using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _distance;

    private IRaycastable _raycastable;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * _distance, Color.black);
        if (!Physics.Raycast(transform.position, transform.forward, out var info, _distance, _layerMask))
        {
            if (_raycastable != null) _raycastable.RaycastTriger(false);
            _raycastable = null;
            return;
        }

        if (!info.collider.gameObject.TryGetComponent<IRaycastable>(out var raycastable))
        {
            if(_raycastable != null) _raycastable.RaycastTriger(false);
            _raycastable = null;
            return;
        }

        if (_raycastable == raycastable) return;
        if (_raycastable != null) _raycastable.RaycastTriger(false);

        _raycastable = raycastable;

        _raycastable.RaycastTriger(true, this);
    }
}
