using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentLine : MonoBehaviour
{
    private Transform _componentTransform;
    private Transform _signTransform;

    private bool _isInit = false;
    private LineRenderer _lineRenderer;

    public void Init(Transform component, Transform sign)
    {
        _componentTransform = component;
        _signTransform = sign;

        _lineRenderer = GetComponent<LineRenderer>();

        _isInit = true;
    }

    private void Update()
    {
        if (!_isInit) return;

        var positions  = new Vector3[] { _componentTransform.position, _signTransform.position};
        _lineRenderer.SetPositions(positions);
    }
}
