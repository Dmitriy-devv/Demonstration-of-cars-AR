using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsSync : MonoBehaviour
{
    [SerializeField] private Transform _FRWheel;
    [SerializeField] private Transform _FLWheel;
    [SerializeField] private Transform _BRWheel;
    [SerializeField] private Transform _BLWheel;

    [SerializeField] private WheelCollider _FRWheelCollider;
    [SerializeField] private WheelCollider _FLWheelCollider;
    [SerializeField] private WheelCollider _BRWheelCollider;
    [SerializeField] private WheelCollider _BLWheelCollider;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        SyncWheel(_FRWheelCollider, _FRWheel);
        SyncWheel(_FLWheelCollider, _FLWheel);
        SyncWheel(_BRWheelCollider, _BRWheel);
        SyncWheel(_BLWheelCollider, _BLWheel);
    }

    private void SyncWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        wheelCollider.GetWorldPose(out var position, out var rotation);

        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }
}
