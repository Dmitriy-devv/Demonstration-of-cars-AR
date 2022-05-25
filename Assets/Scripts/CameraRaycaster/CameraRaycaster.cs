using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private LayerMask _layerMaskRaycast;
    [SerializeField] private float _distance;

    private IRaycastable _raycastable;

    private void Start()
    {
        var camera = GetComponent<Camera>();
        camera.eventMask = _layerMask;
    }

    private void Update()
    {
        if (!Physics.Raycast(transform.position, transform.forward, out var info, _distance, _layerMaskRaycast))
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
