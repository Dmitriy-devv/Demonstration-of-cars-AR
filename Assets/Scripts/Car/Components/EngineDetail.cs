using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    [RequireComponent(typeof(Animator))]
    public class EngineDetail : CarComponent
    {
        private Animator _animator;
        private AudioSource _audioSource;
        private Coroutine _coroutine;

        public override void Init(ICar car)
        {
            base.Init(car);
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
        }

        protected override void OnClick()
        {
            _animator.Play("Action");
            _audioSource.Play();
            if(_coroutine == null) _coroutine = StartCoroutine(UpdateLine());
        }

        private IEnumerator UpdateLine()
        {
            var t = 0f;

            while(t < 0.3f)
            {
                t += Time.deltaTime;
                yield return null;
            }

            _coroutine = null;
        }
    }
}