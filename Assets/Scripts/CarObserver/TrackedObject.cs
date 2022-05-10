using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedObject : MonoBehaviour
{
    private void Start()
    {
        EventHandler.instance.TrackedObjectSpawned(this);
    }


    public Transform GetTransform()
    {
        return transform;
    }
}
