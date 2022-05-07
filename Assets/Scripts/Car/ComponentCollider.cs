using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Cars
{
    public class ComponentCollider : MonoBehaviour
    {
        public event Action Click;
        public event Action Hold;

        private void OnMouseDrag()
        {
            Hold?.Invoke();
        }

        private void OnMouseDown()
        {
            Click?.Invoke();
        }
    }
}