using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace Cars
{
    public class ComponentSign : MonoBehaviour
    {
        public event Action Hold;
        public event Action Click;

        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _actionText;

        private CarComponent _carComponent;
        private Transform _lookTarget;
        private Collider _collider;

        public void Init(Transform lookTarget, CarComponent carComponent)
        {
            _collider = GetComponent<Collider>();
            _lookTarget = lookTarget;
            _carComponent = carComponent;
            var info = _carComponent.Info;
            _nameText.text = info.Name;
            _actionText.text = info.ActionText;
        }

        private void Update()
        {
            transform.LookAt(_lookTarget);
        }

        private void OnMouseDrag()
        {
            Hold?.Invoke();
        }

        private void OnMouseDown()
        {
            Click?.Invoke();
        }

        public Vector3 GetLinePosition()
        {
            return _collider.bounds.center - (_collider.bounds.extents.y * transform.up - _collider.bounds.extents.y * transform.up * 0.1f);
        }
    }
}