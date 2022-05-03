using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactable : MonoBehaviour
{
    public event Action OnInteract;

    private void OnMouseDown()
    {
        OnInteract?.Invoke();
    }
}
