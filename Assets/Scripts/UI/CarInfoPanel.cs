using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI carNameText;
    [SerializeField] private TextMeshProUGUI carInfoText;
    [SerializeField] private Image carImage;

    private bool _isInit = false;

    private void Init()
    {

        _isInit = true;
    }

    public void SetInfo(CarInfo info)
    {
        carNameText.text = info.name;
        carInfoText.text = info.info;
        carImage.sprite = info.sprite;
    }

    public void Show()
    {
        if (!_isInit)
            Init();

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
