using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI carNameText;
    [SerializeField] private TextMeshProUGUI carInfoText;
    [SerializeField] private TextMeshProUGUI carTagText;
    [SerializeField] private Image carImage;

    private float _widthStart;
    private bool _isInit = false;

    private void Init()
    {
        _widthStart = carImage.rectTransform.rect.width;
        _isInit = true;
    }

    public void SetInfo(CarInfo info)
    {
        carImage.sprite = info.sprite;
        carTagText.text = info.tagText;
        carNameText.text = info.name;
        carInfoText.text = info.info;
        
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
