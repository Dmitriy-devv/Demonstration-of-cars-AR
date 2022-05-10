using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.XR.ARSubsystems;
using Cars;

public class CarObserver : MonoBehaviour
{
    [SerializeField] private FindPanel _findPanel;
    [SerializeField] private InfoPanel _infoPanel;
    [SerializeField] private string carsLibraryPath;

    private GameObject currentCar;
    private CarsLibrarySO carsLibrary;
    private Dictionary<string, TrackedObject> _trackedObjects;
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

        carsLibrary = Resources.Load(carsLibraryPath) as CarsLibrarySO;

        _findPanel.Show();
        _infoPanel.Hide();
    }

    private void OnTrackedObjectSpawned(TrackedObject obj)
    {
        _trackedObjectTemp = obj;
    }

    [ContextMenu("ImageUpdated")]
    private void ImageUpdated()
    {
        var image = "qr1";
        if (_trackedObjectTemp != null)
        {
            _trackedObjects.Add(image, _trackedObjectTemp);
            _trackedObjectTemp = null;
        }

        if (currentCar != null)
            Destroy(currentCar);

        //Update Info Panel
        var info = carsLibrary.GetCarInfo(image);
        _findPanel.Hide();
        _infoPanel.Show(info);

        //Spawn Car
        var car = carsLibrary.GetCar(image);
        currentCar = Instantiate(car.gameObject, _trackedObjects[image].GetTransform());
        currentCar.GetComponent<ICar>().Init();
    }

    private void ImageUpdated(string image)
    {
        if(_trackedObjectTemp != null)
        {
            _trackedObjects.Add(image, _trackedObjectTemp);
            _trackedObjectTemp = null;
        }

        if (currentCar != null)
            Destroy(currentCar);

        //Update Info Panel
        var info = carsLibrary.GetCarInfo(image);
        _findPanel.Hide();
        _infoPanel.Show(info);

        //Spawn Car
        var car = carsLibrary.GetCar(image);
        currentCar = Instantiate(car.gameObject, _trackedObjects[image].GetTransform());
        currentCar.GetComponent<ICar>().Init();
    }

    private void ImageEmpty()
    {
        _infoPanel.Hide();
        _findPanel.Show();

        //Remove Car
        if(currentCar != null)
            Destroy(currentCar);
    }

}
