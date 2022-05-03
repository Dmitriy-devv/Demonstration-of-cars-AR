using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HornButton : MonoBehaviour, IPointerDownHandler
{
    public event Action OnButtonDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonDown?.Invoke();
    }

}
