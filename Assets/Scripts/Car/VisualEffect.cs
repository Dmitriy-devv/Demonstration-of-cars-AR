using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffect : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;

    private ParticleSystem _particleSystem;
    private bool _isInit = false;

    private void Init()
    {
        _particleSystem = GetComponent<ParticleSystem>();

        _isInit = true;
    }

    public void Play()
    {
        if (!_isInit) Init();

        _particleSystem.Play(true);
        StartCoroutine(DelayDestroy());
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(_timeToDestroy);

        Destroy(gameObject);
    }
}
