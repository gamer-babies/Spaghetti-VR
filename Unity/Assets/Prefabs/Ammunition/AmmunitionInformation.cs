using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ammunition
{
    public class AmmunitionInformation : MonoBehaviour
    {
        [Tooltip("Maximum lifetime in seconds. <= 0 means there is no lifetime")]
        public float lifetime;

        void Start()
        {
            if (lifetime > 0)
            {
                Destroy(gameObject, lifetime);
            }
        }
    }
}