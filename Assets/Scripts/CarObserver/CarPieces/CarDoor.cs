using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDoor : CarPiece
{
    [SerializeField] private Transform _openTransform;
    [SerializeField] private float timeOpen;
    private Quaternion _closeRotation;

    [SerializeField] private Transform pivot;

    private Coroutine doorAnim;
    private bool _isON = false;

    public override void Init()
    {
        _interactable = GetComponent<Interactable>();
        _interactable.OnInteract += Execute;

        _closeRotation = pivot.localRotation;
    }

    public override void Execute()
    {
        if (doorAnim != null)
            return;

        if(_isON)
        {
            doorAnim = StartCoroutine(CloseDoor());
        }
        else
        {
            doorAnim = StartCoroutine(OpenDoor());
        }
        
    }

    private IEnumerator OpenDoor()
    {

        var t = 0f;

        while(t < timeOpen)
        {

            var a = t / timeOpen;
            pivot.localRotation =  Quaternion.Lerp(_closeRotation, _openTransform.localRotation, a);

            t += Time.deltaTime;
            yield return null;
        }

        pivot.localRotation = _openTransform.localRotation;
        _isON = true;
        doorAnim = null;
    }

    private IEnumerator CloseDoor()
    {
        var t = 0f;

        while (t < timeOpen)
        {

            var a = t / timeOpen;
            pivot.localRotation = Quaternion.Lerp(_openTransform.localRotation, _closeRotation, a);

            t += Time.deltaTime;
            yield return null;
        }

        pivot.localRotation = _closeRotation;
        _isON = false;
        doorAnim = null;
    }

}
