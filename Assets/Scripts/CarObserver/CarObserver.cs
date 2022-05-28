using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using Cars;

public class CarObserver : MonoBehaviour
{
    
    [SerializeField] private FindPanel _findPanel;
    [SerializeField] private InfoPanel _infoPanel;
    [SerializeField] private Material _mainCarMaterial;

    private readonly string _carsLibraryPath = "Cars";

    private GameObject _currentCar;
    private ICar _currentICar;
    private CarsLibrarySO _carsLibrary;
    private Dictionary<string, TrackedObject> _trackedObjects;
    private Dictionary<string, GameObject> _carsSpawned;
    private TrackedObject _trackedObjectTemp;

    private ImageObserver _imageObserver;

    public void Init()
    {
        _imageObserver = GetComponent<ImageObserver>();
        _imageObserver.OnImageUpdated += ImageUpdated;
        _imageObserver.OnImageEmpty += ImageEmpty;
        _imageObserver.Init();

        _trackedObjects = new Dictionary<string, TrackedObject>();
        EventHandler.instance.OnTrackedObjectSpawned += OnTrackedObjectSpawned;

        _carsLibrary = Resources.Load(_carsLibraryPath) as CarsLibrarySO;

        _findPanel.Show();
        _infoPanel.Hide();
    }

    private void OnTrackedObjectSpawned(TrackedObject obj)
    {
        _trackedObjectTemp = obj;
    }

    [ContextMenu("Test/QR1")]
    public void TestImage1()
    {
        ImageUpdated("qr1");
    }

    [ContextMenu("Test/QR2")]
    public void TestImage2()
    {
        ImageUpdated("qr2");
    }

    private void ImageUpdated(string image)
    {
        if (_trackedObjectTemp != null)
        {
            _trackedObjects.Add(image, _trackedObjectTemp);
            _trackedObjectTemp = null;
        }

        if (_currentCar != null)
            Destroy(_currentCar);

        //Update Info Panel
        var info = _carsLibrary.GetCarInfo(image);
        _findPanel.Hide();
        _infoPanel.Show(info);

        //Spawn Car
        var car = _carsLibrary.GetCar(image);
        _currentCar = Instantiate(car.gameObject, _trackedObjects[image].GetTransform());
        _currentCar.GetComponent<ICar>().Init();
    }

    private void ImageEmpty()
    {
        if (_currentCar != null)
            Destroy(_currentCar);

        _infoPanel.Hide();
        _findPanel.Show();
    }

    

}
