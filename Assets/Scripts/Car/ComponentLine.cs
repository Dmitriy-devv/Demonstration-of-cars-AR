using Cars;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentLine : MonoBehaviour
{
    [SerializeField] private int _countPoints;

    private Transform _componentTransform;
    private ComponentSign _sign;

    private LineRenderer _lineRenderer;

    public void Init(Transform component, ComponentSign sign)
    {
        _componentTransform = component;
        _sign= sign;

        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _countPoints;
        UpdateLine();
    }

    public void UpdateLine()
    {
        var positions = new Vector3[_countPoints];
        var signPos = _sign.GetLinePosition();
        var componetPos = _componentTransform.position;
        var deltaX = (signPos.x - componetPos.x);
        var deltaY = (signPos.y - componetPos.y);
        var deltaZ = (signPos.z - componetPos.z);
        for (int i = 0; i < _countPoints - 1; i++)
        {
            var value = (float)i / (_countPoints - 1);
            var func = value * value * value * value * value;
            var x = componetPos.x + value * deltaX;
            var y = componetPos.y + func * deltaY;
            var z = componetPos.z + value * deltaZ;
            positions[i] = new Vector3(x, y, z);
        }

        positions[_countPoints - 1] = signPos;

        _lineRenderer.SetPositions(positions);
    }


}
