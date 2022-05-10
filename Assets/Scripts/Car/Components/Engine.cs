using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cars
{
    public class Engine : CarComponent
    {
        public bool State => _state;

        [SerializeField][Range(0, 1f)] private float _defaultVolume;
        [SerializeField][Range(0, 1f)] private float _hoodVolume;
        [SerializeField][Range(0, 1f)] private float _maxAccelerationVolume;

        [SerializeField] private AudioSource _audioSourceEngine;
        [SerializeField] private AudioSource _audioSourceAcceleration;

        private bool _state;
        private bool _isHood;
        private float _engineAcceleration = 0f;

        public override void Init(ICar car)
        {
            base.Init(car);
            _audioSourceAcceleration.volume = 0f;
            _audioSourceAcceleration.Play();
        }

        protected sealed override void OnClick()
        {
            _state = !_state;
            if (_state) _audioSourceEngine.Play();
            else _audioSourceEngine.Stop();
        }

        public void SetEngineHood(bool isHood)
        {
            _isHood = isHood;
        }

        
        /// <param name="value">Must be from 0 to 1</param>
        public void SetEngineAcceleration(float value)
        {
            _engineAcceleration = Mathf.Clamp(value, 0f, 1f);

            _audioSourceEngine.volume = _isHood ? _defaultVolume : _hoodVolume;
            _audioSourceEngine.volume *= 1f - _engineAcceleration;

            var vol = _maxAccelerationVolume * _engineAcceleration;
            _audioSourceAcceleration.volume = _isHood ? _defaultVolume * vol : _hoodVolume * vol;
            _audioSourceAcceleration.pitch = _engineAcceleration * 1f;
        }

    }
}