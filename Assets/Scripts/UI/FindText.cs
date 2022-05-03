using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindText : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _speed = 15;

    private TMPro.TextMeshProUGUI _text;

    private Coroutine   _animCoroutine;
    private string      _startText;
    private bool        _isInit = false;

    private void Init()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();
        _startText = _text.text;
        _animCoroutine = null;
        _isInit = true;
    }

    public void StartAnim()
    {
        if (!_isInit) Init();

        _animCoroutine = StartCoroutine(Anim());
    }

    public void StopAnim()
    {
        if (_animCoroutine != null)
        {
            _text.text = _startText;
            StopCoroutine(_animCoroutine);
        }
    }

    private IEnumerator Anim()
    {
        yield return null;

        var amountPoint = 0;

        while (true)
        {
            if (amountPoint < 3)
            {
                _text.text += ".";
                amountPoint++;
            }
            else
            {
                amountPoint = 0;
                _text.text = _startText;
            }
            

            yield return new WaitForSeconds(1 / _speed);
        }

    }
}
