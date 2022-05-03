using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private List<CarPiece> carPieces;

    public void Init()
    {
        foreach (var piece in carPieces)
        {
            piece.Init();
        }
    }
}
