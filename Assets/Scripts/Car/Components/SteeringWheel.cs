using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    [RequireComponent(typeof(AudioSource))]
    public class SteeringWheel : CarComponent
    {
        private AudioSource _audioSource;

        public override void Init(ICar car)
        {
            base.Init(car);
            _audioSource = GetComponent<AudioSource>();
        }

        protected sealed override void OnClick()
        {
            //Check Accum
            _audioSource.Play();
        }
    }
}