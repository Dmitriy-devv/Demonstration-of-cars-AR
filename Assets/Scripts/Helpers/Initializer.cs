using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    //Singletons
    [SerializeField] private EventHandler   _eventHandler;

    //Others
    [SerializeField] private MainPanel      _mainPanel;
    [SerializeField] private CarObserver    _carObserver;


    private void Start()
    {
        _eventHandler.Init();

        _mainPanel.Show();
        _carObserver.Init();
    }

}
