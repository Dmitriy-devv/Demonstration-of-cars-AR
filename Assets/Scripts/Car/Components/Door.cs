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

        private AudioSource _audioSource;
        private Quaternion _closeRotation;
        private bool _direction = false;
        private Coroutine _doorAnim;
        private Vector3 _rightDirectionForce;

        public override void Init(ICar car)
        {
            base.Init(car);
            _closeRotation = _pivot.localRotation;
            _rightDirectionForce = _isInverseForceDirection ? -transform.right : transform.right;
            _audioSource = GetComponent<AudioSource>();
        }

        protected sealed override void OnClick()
        {
            if (_doorAnim != null)
                return;

            _doorAnim = _direction ? StartCoroutine(OpenDoor(_openTransform.rotation, _closeRotation)) : StartCoroutine(OpenDoor(_closeRotation, _openTransform.rotation));
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

                if (_currentLine != null) _currentLine.UpdateLine();

                t += Time.deltaTime;
                yield return null;
            }

            _pivot.localRotation = to;
            _car.AddForce(_rightDirectionForce, transform.position, _direction ? -_force : _force);
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