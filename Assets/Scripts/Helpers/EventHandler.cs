using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : MonoBehaviour
{
    public static EventHandler instance { get; private set; }
    public event Action<TrackedObject> OnTrackedObjectSpawned;

    public void Init()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    public void TrackedObjectSpawned(TrackedObject trackedObject)
    {
        OnTrackedObjectSpawned?.Invoke(trackedObject);
    }
}
