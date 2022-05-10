using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    private Light _light;
    [SerializeField] private float _maxValue;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _time;

    private IEnumerator Start()
    {
        var t = 0f;
        _light = GetComponent<Light>();
        while(t < _time)
        {
            var x = t / _time;
            _light.intensity = _curve.Evaluate(x) * _maxValue;

            t += Time.deltaTime;
            yield return null;
        }
    }
}
