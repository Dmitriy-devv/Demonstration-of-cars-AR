using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cars
{
    [RequireComponent(typeof(AudioSource))]
    public class Accumulator : CarComponent
    {
        public event Action<bool> Changed;
        public bool State => _state;

        private AudioSource _audioSource;
        private bool _state;

        public override void Init(ICar car)
        {
            base.Init(car);
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