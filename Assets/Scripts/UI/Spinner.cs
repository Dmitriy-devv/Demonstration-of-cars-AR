using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _speed = 15;
    [SerializeField] private float          _angle = 15;

    private RectTransform   _rectTransform;
    private Coroutine       _rotateCoroutine;

    private bool _isInit = false;

    private void Init()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rotateCoroutine = null;

        _isInit = true;
    }

    public void StartRotation()
    {
        if (!_isInit) Init();

        _rotateCoroutine =  StartCoroutine(Rotate());
    }

    public void StopRotation()
    {
        if(_rotateCoroutine != null)
        {
            StopCoroutine(_rotateCoroutine);
        }
    }

    private IEnumerator Rotate()
    {
        yield return null;

        while (true)
        {
            _rectTransform.Rotate(Vector3.back * _angle);

            yield return new WaitForSeconds(1 / _speed);
        }

    }
}
