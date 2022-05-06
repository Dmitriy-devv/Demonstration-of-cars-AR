using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class CarSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private CarTest _car;

        private GameObject _carObj;


        private void Start()
        {
            Init();
        }

        public void Init()
        {
            SpawnCar();
        }

        [ContextMenu("Test/Spawn")]
        public void SpawnCar()
        {
            if (_carObj != null) return;

            var car = Instantiate(_car, _spawnTransform.position, _spawnTransform.rotation);
            car.Init();
            _carObj = car.gameObject;
        }

        [ContextMenu("Test/Destroy")]
        public void DestroyCar()
        {
            if (_carObj == null) return;

            Destroy(_carObj);
        }
    }
}