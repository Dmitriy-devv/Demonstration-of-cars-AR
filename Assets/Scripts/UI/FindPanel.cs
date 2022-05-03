using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPanel : MonoBehaviour
{
    [SerializeField] private FindText   _findText;
    [SerializeField] private Spinner    _spinner;

    private bool _isInit = false;
    private void Init()
    {

        _isInit = true;
    }

    [ContextMenu("Test/Show")]
    public void Show()
    {
        if (!_isInit)
            Init();
        gameObject.SetActive(true);
        _findText.StartAnim();
        _spinner.StartRotation();
        
    }

    [ContextMenu("Test/Hide")]
    public void Hide()
    {
        _findText.StopAnim();
        _spinner.StopRotation();
        gameObject.SetActive(false);
    }
}
