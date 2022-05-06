using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComponent : MonoBehaviour, IRaycastable
{
    public void RaycastTriger()
    {
        var material = GetComponent<MeshRenderer>().material;
        material.color = Random.ColorHSV();
    }
}
