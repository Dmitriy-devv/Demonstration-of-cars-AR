using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSign : MonoBehaviour
{
    private Transform _lookTarget;
    public void Init(Transform lookTarget)
    {
        _lookTarget = lookTarget;
    }

    private void Update()
    {
        transform.LookAt(_lookTarget);
    }
}
