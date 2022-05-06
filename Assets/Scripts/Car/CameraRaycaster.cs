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
            _raycastable = null;
            return;
        }
        Debug.Log(info.collider.gameObject.name);
        if (!info.collider.gameObject.TryGetComponent<IRaycastable>(out var raycastable))
        {
            _raycastable = null;
            return;
        }

        if (_raycastable == raycastable) return;
        _raycastable = raycastable;

        _raycastable.RaycastTriger();
    }
}
