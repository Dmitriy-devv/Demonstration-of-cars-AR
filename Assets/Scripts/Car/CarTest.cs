using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class CarTest : MonoBehaviour
    {
        [SerializeField] private VisualEffect _spawnEffect;
        [SerializeField] private ComponentLine _line;
        [SerializeField] private ComponentSign _sign;

        private CarAnimator _carAnimator;

        public void Init()
        {
            var components = GetComponentsInChildren<CarComponent>(true);
            foreach (var component in components)
            {
                component.Init(_sign, _line);
            }

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