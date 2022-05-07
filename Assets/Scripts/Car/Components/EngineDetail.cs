using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    [RequireComponent(typeof(Animator))]
    public class EngineDetail : CarComponent
    {
        private Animator _animator;

        private Coroutine _coroutine;

        public override void Init(ComponentSign sign, ComponentLine line)
        {
            base.Init(sign, line);
            _animator = GetComponent<Animator>();
        }

        protected override void OnClick()
        {
            _animator.Play("Action");
            if(_coroutine == null) _coroutine = StartCoroutine(UpdateLine());
        }

        private IEnumerator UpdateLine()
        {
            var t = 0f;

            while(t < 0.3f)
            {
                if (_currentLine != null) _currentLine.UpdateLine();
                t += Time.deltaTime;
                yield return null;
            }

            _coroutine = null;
        }
    }
}