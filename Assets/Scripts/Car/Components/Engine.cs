using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cars
{
    public class Engine : CarComponent
    {
        [SerializeField][Range(0, 1f)] private float _defaultVolume;
        [SerializeField][Range(0, 1f)] private float _hoodVolume;

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

        public void EngineHood(bool isHood)
        {
            _audioSource.volume = isHood ? _defaultVolume : _hoodVolume;
        }
    }
}