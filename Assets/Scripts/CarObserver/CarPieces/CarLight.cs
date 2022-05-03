using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLight : CarPiece
{

    [SerializeField] private CarLight otherLight;
    [SerializeField] private Light _light;

    private bool _isON = false;

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
    }
}
