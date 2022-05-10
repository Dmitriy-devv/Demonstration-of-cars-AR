using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class Door : CarComponent
    {
        [Header("Door")]
        [SerializeField] private Transform _openTransform;
        [SerializeField] private Transform _pivot;
        [SerializeField] private float _timeOpen;
        [SerializeField] private float _force;
        [SerializeField] private bool _isInverseForceDirection;
        [SerializeField] private AudioClip _openSound;
        [SerializeField] private AudioClip _closeSound;
        [SerializeField] private Transform _carForwardTransform;

        private AudioSource _audioSource;
        private Quaternion _closeRotation;
        private bool _direction = false;
        private Coroutine _doorAnim;

        public override void Init(ICar car)
        {
            base.Init(car);
            _closeRotation = _pivot.localRotation;
            _audioSource = GetComponent<AudioSource>();
        }

        protected sealed override void OnClick()
        {
            if (_doorAnim != null)
                return;

            _doorAnim = _direction ? StartCoroutine(OpenDoor(_openTransform.localRotation, _closeRotation)) : StartCoroutine(OpenDoor(_closeRotation, _openTransform.localRotation));
        }

        private IEnumerator OpenDoor(Quaternion from, Quaternion to)
        {
            if (!_direction)
            {
                _audioSource.clip = _openSound;
                _audioSource.Play();
            }
            var t = 0f;

            while (t < _timeOpen)
            {

                var a = t / _timeOpen;
                _pivot.localRotation = Quaternion.Lerp(from, to, a);

                t += Time.deltaTime;
                yield return null;
            }

            _pivot.localRotation = to;
            var dirF = _isInverseForceDirection ? -1f : 1f;
            _car.AddForce(_carForwardTransform.right * dirF, transform.position, _direction ? -_force : _force);
            if (_direction)
            {
                _audioSource.clip = _closeSound;
                _audioSource.Play();
            }
            _direction = !_direction;
            _doorAnim = null;
        }

    }
}