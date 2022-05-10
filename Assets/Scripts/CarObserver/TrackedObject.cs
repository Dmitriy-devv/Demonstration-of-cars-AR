using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedObject : MonoBehaviour
{
    private void Start()
    {
        EventHandler.instance.TrackedObjectSpawned(this);
    }

    private void Update()
    {
        DebugUI.instance.Log(transform.position.ToString());
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
