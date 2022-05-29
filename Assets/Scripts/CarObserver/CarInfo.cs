using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class CarInfo 
{
    public string name;
    [Multiline(10)]public string info;
    public string tagText;
    public Sprite sprite;
}
