using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Cars
{
    public class CarTest : MonoBehaviour, ICar
    {
        public ComponentLine ComponentLine => _line;
        public ComponentSign ComponentSign => _sign;
        public Engine Engine => _engine;

        [SerializeField] private VisualEffect _spawnEffect;
        [SerializeField] private ComponentLine _line;
        [SerializeField] private ComponentSign _sign;
        [SerializeField] private Engine _engine;
        
        private CarAnimator _carAnimator;
        private Rigidbody _rigidbody;

        public void Init()
        {
            var components = GetComponentsInChildren<CarComponent>(true);
            
            foreach (var component in components)
            {
                component.Init(this);
            }

            _rigidbody = GetComponent<Rigidbody>();

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

        public void AddForce(Vector3 direction, Vector3 position, float force)
        {
            _rigidbody.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }
}