using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public interface ICar
    {
        public ComponentLine ComponentLine { get; }
        public ComponentSign ComponentSign { get; }
        public Engine Engine { get; }

        public void AddForce(Vector3 direction, Vector3 position, float force);
        
    }
}