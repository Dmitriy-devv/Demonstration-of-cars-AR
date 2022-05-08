using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VisualEffect : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private GameObject _objToActive;
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
        if(_objToActive != null) _objToActive.SetActive(true);
        _particleSystem.Play(true);
        StartCoroutine(DelayDestroy());
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        
        Destroy(gameObject);
    }
}
