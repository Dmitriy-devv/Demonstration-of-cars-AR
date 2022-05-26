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
        private bool _isInit = false;

        public override void Init(ICar car)
        {
            base.Init(car);
            _isInit = true;
        }

        protected override void OnHold()
        {
            if (!_car.Engine.State) return;

            _t += Mathf.Clamp(_t + Time.deltaTime * 2f *_speed, 0f, 1f);
            _car.AddForce(_forcePosition.position, _forcePosition.up, _force);
            _otherWheel.UpdateSpeed(_t);
        }

        private void Update()
        {
            if (!_isInit) return;
            _wheelCollider.motorTorque = _t * _maxSpeed;
            transform.position = _wheelTransform.position;
            _t = Mathf.Clamp(_t - Time.deltaTime * _speed, 0f, 1f);
            
            var em = _particleSystem.emission;
            var rate = Mathf.Clamp(_wheelCollider.rpm - 1f, 0f, 500f) / 5f;
            em.rateOverTime = rate;
            _car.Engine.SetEngineAcceleration(rate / 100f);
        }

        public void UpdateSpeed(float value)
        {
            _t = value;
        }
    }
}