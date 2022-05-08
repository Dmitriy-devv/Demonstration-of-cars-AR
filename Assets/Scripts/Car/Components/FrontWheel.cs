using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class FrontWheel : CarComponent
    {
        [SerializeField] private float _speedRotate;

        [SerializeField] private WheelCollider _wheelCollider;
        [SerializeField] private FrontWheel _otherWheel;
        [SerializeField] private float _maxAngle;

        private bool _direction = false;
        private float _angle;

        public override void Init(ICar car)
        {
            base.Init(car);
            _angle = 0f;

        }

        protected override void OnHold()
        {
            var delta = Time.deltaTime * _speedRotate;
            _angle = _direction ? _angle + delta: _angle - delta;
            if (_angle > _maxAngle) _direction = false;
            if (_angle < -_maxAngle) _direction = true;
            SetRotation(_angle, _direction);
            _otherWheel.SetRotation(_angle, _direction);
            
        }

        public void SetRotation(float value, bool direction)
        {
            _angle = value;
            _direction = direction;
            _wheelCollider.steerAngle = _angle;
            if (_currentLine != null) _currentLine.UpdateLine();
        }
    }
}