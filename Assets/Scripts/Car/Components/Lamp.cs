using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class Lamp : CarComponent
    {
        [SerializeField] private Lamp _otherLamp;
        [SerializeField] private Light _light;
        [SerializeField] private AudioClip _onSound;
        [SerializeField] private AudioClip _offSound;

        private AudioSource _audioSource;
        private bool _state;

        public override void Init(ICar car)
        {
            base.Init(car);
            _state = false;

            _audioSource = GetComponent<AudioSource>();
        }

        protected override void OnClick()
        {
            var value = !_state;
            Turn(value);
            _otherLamp.Turn(value);
        }

        public void Turn(bool value)
        {
            _state = value;
            _light.gameObject.SetActive(value);
            _audioSource.clip = value ? _onSound : _offSound;
            _audioSource.Play();
        }
    }
}