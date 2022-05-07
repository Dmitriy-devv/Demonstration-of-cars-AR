using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class CarComponent : MonoBehaviour, IRaycastable, ICarComponent
    {
        public ComponentInfo Info => _info;

        [SerializeField] private ComponentInfo _info;

        private Transform _signPosition;
        private ComponentSign _signPrefab;
        private ComponentSign _currentSign;
        private ComponentLine _linePrefab;
        protected ComponentLine _currentLine;

        public virtual void Init(ComponentSign sign, ComponentLine line)
        {
            _signPrefab = sign;
            _signPosition = GetComponentInChildren<SignPosition>().transform;

            _linePrefab = line;

            var rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;

            var collider = GetComponent<ComponentCollider>();
            collider.Click += OnClick;
            collider.Hold += OnHold;
        }

        public virtual void RaycastTriger(bool value, CameraRaycaster raycaster = null)
        {
            if (!value)
            {
                if (_currentSign != null) Destroy(_currentSign.gameObject);
                if (_currentLine != null) Destroy(_currentLine.gameObject);

                return;
            }

            _currentSign = Instantiate(_signPrefab, _signPosition.position, Quaternion.identity, _signPosition.transform);
            _currentSign.Init(raycaster.transform, this);
            _currentSign.Click += OnClick;
            _currentSign.Hold += OnHold;

            _currentLine = Instantiate(_linePrefab);
            _currentLine.Init(transform, _currentSign);
        }

        protected virtual void OnHold() { }
        protected virtual void OnClick() { }
        
        private void OnDestroy()
        {
            if (_currentSign != null) Destroy(_currentSign.gameObject);
            if (_currentLine != null) Destroy(_currentLine.gameObject);
        }
    }
}