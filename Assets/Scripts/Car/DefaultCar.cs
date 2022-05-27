using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Cars
{
    public class DefaultCar : MonoBehaviour, ICar
    {
        public ComponentLine ComponentLine => _line;
        public ComponentSign ComponentSign => _sign;
        public Engine Engine => _engine;


        [SerializeField] private VisualEffect _spawnEffect;
        [SerializeField] private ComponentLine _line;
        [SerializeField] private ComponentSign _sign;
        [SerializeField] private Engine _engine;
        [SerializeField] private float _signScale = 1f;

        private CarAnimator _carAnimator;
        private Rigidbody _rigidbody;

        public void Init()
        {
            var components = GetComponentsInChildren<CarComponent>(true);
            
            foreach (var component in components)
            {
                component.Init(this);
            }

            var signPostions = GetComponentsInChildren<SignPosition>(true);

            foreach (var sign in signPostions)
            {
                sign.transform.localScale = sign.transform.localScale * _signScale;
            }

            _rigidbody = GetComponent<Rigidbody>();
            _carAnimator = GetComponent<CarAnimator>();
            _carAnimator.Init();
            _carAnimator.SpawnAnimation();

            var effect = Instantiate(_spawnEffect, transform.position, transform.rotation);
            effect.Play();
        }

        public void AddForce(Vector3 direction, Vector3 position, float force)
        {
            _rigidbody.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }

    }
}