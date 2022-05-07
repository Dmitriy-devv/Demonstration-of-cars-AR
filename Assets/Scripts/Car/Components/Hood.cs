using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class Hood : CarComponent
    {
        [Header("Hood")]
        [SerializeField] private GameObject _engineObj;
        [SerializeField] private Transform _openTransform;
        [SerializeField] private Transform _pivot;
        [SerializeField] private float _timeOpen;

        private Quaternion _closeRotation;
        private bool _direction = false;
        private Coroutine _doorAnim;

        public override void Init(ComponentSign sign, ComponentLine line)
        {
            base.Init(sign, line);
            _closeRotation = _pivot.localRotation;
        }

        protected sealed override void OnClick()
        {
            if (_doorAnim != null)
                return;

            _doorAnim = _direction ? StartCoroutine(OpenDoor(_openTransform.rotation, _closeRotation)) : StartCoroutine(OpenDoor(_closeRotation, _openTransform.rotation));
        }

        private IEnumerator OpenDoor(Quaternion from, Quaternion to)
        {
            if (!_direction) SetEngine(true);
            var t = 0f;

            while (t < _timeOpen)
            {

                var a = t / _timeOpen;
                _pivot.localRotation = Quaternion.Lerp(from, to, a);

                if (_currentLine != null) _currentLine.UpdateLine();

                t += Time.deltaTime;
                yield return null;
            }

            _pivot.localRotation = to;
            _direction = !_direction;
            if (!_direction) SetEngine(false);
            _doorAnim = null;
        }

        private void SetEngine(bool value)
        {
            _engineObj.SetActive(value);
        }
    }
}