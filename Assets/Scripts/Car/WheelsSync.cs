using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cars
{
    public class WheelsSync : MonoBehaviour
    {
        [SerializeField] private float _brakeTorque = 1000f;
        [SerializeField] private List<WheelSet> _wheels;

        private void FixedUpdate()
        {
            foreach (var wheel in _wheels)
            {
                SyncWheel(wheel);
                wheel.Collider.brakeTorque = _brakeTorque;
            }
        }

        private void SyncWheel(WheelSet wheelSet)
        {
            wheelSet.Collider.GetWorldPose(out var position, out var rotation);

            wheelSet.Transform.position = position;
            wheelSet.Transform.rotation = rotation;
        }

        [Serializable]
        private class WheelSet
        {
            public WheelCollider Collider;
            public Transform Transform;
        }
    }
}