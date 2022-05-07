using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cars
{
    public class CarAnimator : MonoBehaviour
    {
        public event Action Spawned;

        private readonly string _spawnAnimation = "SpawnAnimation";

        private int _spawnHash;
        private Animator _animator;

        public void Init()
        {
            _spawnHash = Animator.StringToHash(_spawnAnimation);
            _animator = GetComponent<Animator>();
        }

        public void SpawnAnimation()
        {
            _animator.Play(_spawnHash);
        }


        public void SpawnAnimationEnd()
        {
            Spawned?.Invoke();
        }

    }
}