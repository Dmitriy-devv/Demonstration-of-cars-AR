using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class BackWheel : CarComponent
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _force;

        [SerializeField] private WheelCollider _wheelCollider;
        [SerializeField] private Transform _wheelTransform;
        [SerializeField] private Transform _forcePosition;
        [SerializeField] private BackWheel _otherWheel;
        [SerializeField] private ParticleSystem _particleSystem;

        private float _t;

        public override void Init(ICar car)
        {
            base.Init(car);
            
        }

        protected override void OnHold()
        {
            _t += Mathf.Clamp(_t + Time.deltaTime * 2f *_speed, 0f, 1f);
            _car.AddForce(_forcePosition.position, _forcePosition.up, _force);
            _otherWheel.UpdateSpeed(_t);
        }

        private void Update()
        {
            _wheelCollider.motorTorque = _t * _maxSpeed;
            transform.position = _wheelTransform.position;
            if (_currentLine != null) _currentLine.UpdateLine();
            _t = Mathf.Clamp(_t - Time.deltaTime * _speed, 0f, 1f);
            var em = _particleSystem.emission;
            em.rateOverTime = Mathf.Clamp(_wheelCollider.rpm - 1f, 0f, 500f) / 5f;
        }

        public void UpdateSpeed(float value)
        {
            _t = value;
        }


    }
}