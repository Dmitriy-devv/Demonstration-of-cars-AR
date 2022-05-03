using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DebugUI : MonoBehaviour
{
    public static DebugUI instance { get; private set; }

    [SerializeField] private List<TextMeshProUGUI> _texts;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    public void Log(string msg)
    {
        for (int i = 0; i < _texts.Count - 1; i++)
        {
            _texts[i].text = _texts[i + 1].text;
        }
        _texts[_texts.Count - 1].text = msg + "\nT: " + DateTime.Now.Second;
    }

}
