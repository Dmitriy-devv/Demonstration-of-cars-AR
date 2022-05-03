using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Linq;

public class ImageObserver : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager _imageManager;

    public event Action<string> OnImageUpdated;
    public event Action OnImageEmpty;

    private string _currentImage = string.Empty;

    public void Init()
    {
        _imageManager.trackedImagesChanged += ImageChanged;
    }

    
    private void ImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        if (args.updated.All(image => image.trackingState != TrackingState.Tracking))
        {
            if (_currentImage != string.Empty)
            {
                
                OnImageEmpty?.Invoke();
            }
                
            _currentImage = string.Empty;
            return;
        }

        if (args.updated.Any(image => image.referenceImage.name == _currentImage && image.trackingState == TrackingState.Tracking))
        {
            return;
        }

        var image = args.updated.First( image => image.trackingState == TrackingState.Tracking);
        _currentImage = image.referenceImage.name;
        
        OnImageUpdated?.Invoke(_currentImage);
    }
    
}
