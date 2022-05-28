using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Cars
{
    [Serializable]
    public struct ComponentInfo
    {
        public string Name;
        [Multiline(6)] public string Description;
        public string ActionText;
        public Sprite Icon;
    }
}