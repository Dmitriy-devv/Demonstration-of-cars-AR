using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class CarTest : MonoBehaviour
    {
        [SerializeField] private VisualEffect _spawnEffect;

        private CarAnimator _carAnimator;

        public void Init()
        {
            _carAnimator = GetComponent<CarAnimator>();
            _carAnimator.Spawned += OnSpawned;
            _carAnimator.Init();
            _carAnimator.SpawnAnimation();

            var effect = Instantiate(_spawnEffect, transform.position, transform.rotation);
            effect.Play();
        }

        private void OnSpawned()
        {
            //Can be interacted
        }

    }
}