using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public abstract class CarPiece : MonoBehaviour
{
    protected Interactable _interactable;

    public abstract void Init();

    public abstract void Execute();

}
