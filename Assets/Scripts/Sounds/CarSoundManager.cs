using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarSoundManager : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float _hornVolume = 0.5f;
    [SerializeField] private float _engineVolume = 0.5f;

    private AudioSource _audioSourceEngine;
    private AudioSource _audioSourceHorn;
    private CarInfo _carInfo;

    public void Init(EngineToggle engineToggle, HornButton hornButton)
    {
        _audioSourceHorn = gameObject.AddComponent<AudioSource>();
        _audioSourceHorn.spatialBlend = 1f;
        _audioSourceHorn.minDistance = 0f;
        _audioSourceHorn.maxDistance = 10f;
        _audioSourceHorn.rolloffMode = AudioRolloffMode.Linear;
        _audioSourceHorn.volume = _hornVolume;
        _audioSourceHorn.loop = false;

        _audioSourceEngine = gameObject.AddComponent<AudioSource>();
        _audioSourceEngine.spatialBlend = 1f;
        _audioSourceEngine.minDistance = 0f;
        _audioSourceEngine.maxDistance = 10f;
        _audioSourceEngine.rolloffMode = AudioRolloffMode.Linear;
        _audioSourceEngine.volume = _engineVolume;
        _audioSourceEngine.loop = true;

        
        engineToggle.OnValueChanged += PlayEngine;
        hornButton.OnButtonDown += PlayHorn;
    }

    public void SetCarInfo(CarInfo carInfo)
    {
        _carInfo = carInfo;
        _audioSourceHorn.Stop();
        _audioSourceEngine.Stop();
    }

    private void PlayEngine(bool state)
    {
        if(state)
        {
            _audioSourceEngine.clip = _carInfo.engineSound;
            _audioSourceEngine.Play();
            return;
        }

        _audioSourceEngine.Stop();
    }

    private void PlayHorn()
    {
        if (_audioSourceHorn.isPlaying)
            return;

        _audioSourceHorn.clip = _carInfo.hornSound;
        _audioSourceHorn.Play();
    }
}
