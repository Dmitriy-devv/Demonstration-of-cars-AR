using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class Lamp : CarComponent
    {
        [SerializeField] private Lamp _otherLamp;
        [SerializeField] private Light _light;

        private bool _state;

        public override void Init(ICar car)
        {
            base.Init(car);
            _state = false;
        }

        protected override void OnClick()
        {
            _state = !_state;
            Turn(_state);
            _otherLamp.Turn(_state);
        }

        public void Turn(bool value)
        {
            _light.gameObject.SetActive(value);
        }
    }
}