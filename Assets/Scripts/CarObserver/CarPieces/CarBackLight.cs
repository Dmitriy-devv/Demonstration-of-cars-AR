using Cars;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBackLight : CarPiece
{
    [SerializeField] private CarBackLight otherLight;
    [SerializeField] private Light _light;
    [SerializeField] private Material lampMaterial;

    private bool _isON = false;
    private Color                   _defaultColor;
    [SerializeField] private Color  _activeColor;

    public override void Init()
    {
        _interactable = GetComponent<Interactable>();
        _interactable.OnInteract += Execute;
        _light.gameObject.SetActive(false);

    }
    public override void Execute()
    {
        var temp = _isON;
        TurnLight(!temp);
        otherLight.TurnLight(!temp);
    }

    public void TurnLight(bool state)
    {
        _isON = !_isON;
        _light.gameObject.SetActive(state);
        if(state)
        {
            lampMaterial.color = _activeColor;
        }
        else
        {
            lampMaterial.color = _defaultColor;
        }
    }
}
