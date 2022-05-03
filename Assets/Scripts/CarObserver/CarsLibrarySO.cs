using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "Cars")]
public class CarsLibrarySO : ScriptableObject
{
    [SerializeField] private List<CarAsset> cars;

    [Serializable]
    private class CarAsset
    {
        public string prefabName;
        public string markerName;
        public Car car;
        public CarInfo carInfo;
    }

    public Car GetCar(string marker)
    {
        if(!cars.Any(x => x.markerName == marker))
        {
            return null;
        }

        return cars.First(x => x.markerName == marker).car;
    }

    public CarInfo GetCarInfo(string marker)
    {
        if (!cars.Any(x => x.markerName == marker))
        {
            return null;
        }

        return cars.First(x => x.markerName == marker).carInfo;
    }
}
