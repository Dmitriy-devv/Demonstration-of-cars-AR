using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    [RequireComponent(typeof(AudioSource))]
    public class Accumulator : CarComponent
    {
        public bool State => _state;

        private AudioSource _audioSource;
        private bool _state;

        public override void Init(ComponentSign sign, ComponentLine line)
        {
            base.Init(sign, line);
            _audioSource = GetComponent<AudioSource>();
        }

        protected sealed override void OnClick()
        {
            _state = !_state;
            if (_state) _audioSource.Play();
            else _audioSource.Stop();
        }
    }
}