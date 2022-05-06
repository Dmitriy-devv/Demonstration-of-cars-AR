using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComponent : MonoBehaviour, IRaycastable
{
    private ComponentSign _signPrefab;

    private GameObject _signObj;

    public void Init(ComponentSign sign)
    {
        _signPrefab = sign;
    }

    public void RaycastTriger(bool value, CameraRaycaster raycaster = null)
    {
        if (!value)
        {
            if (_signObj == null) return;

            Destroy(_signObj);
            return;
        }

        var position = transform.position + Vector3.up;
        var sign = Instantiate(_signPrefab, position, Quaternion.identity);
        sign.Init(raycaster.transform);
        _signObj = sign.gameObject;
    }
}
