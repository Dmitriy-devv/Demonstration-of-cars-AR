using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cars
{
    [RequireComponent(typeof(AudioSource))]
    public class Accumulator : CarComponent
    {
        [SerializeField] private VisualEffect _effect;
        [SerializeField] private Transform _effectTransform;

        private Coroutine _coroutine;
        private Animator _animator;
        private AudioSource _audioSource;
        private bool _state;

        public override void Init(ICar car)
        {
            base.Init(car);
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
        }

        protected sealed override void OnClick()
        {
            if (_state) return;

            _state = true;
            _audioSource.Play();
            _animator.Play("Action");
            Instantiate(_effect, _effectTransform.position, _effect.transform.rotation, _effectTransform).Play();
            if (_coroutine == null) _coroutine = StartCoroutine(UpdateLine());
        }

        private IEnumerator UpdateLine()
        {
            var t = 0f;

            while (t < 0.25f)
            {
                t += Time.deltaTime;
                yield return null;
            }

            _state = false;
            _coroutine = null;
        }
    }
}