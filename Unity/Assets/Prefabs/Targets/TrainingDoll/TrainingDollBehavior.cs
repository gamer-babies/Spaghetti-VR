using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Targets
{
    public class TrainingDollBehavior : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            var ammunitionInformation = collision.gameObject.GetComponent<Ammunition.AmmunitionInformation>();
            if (ammunitionInformation == null)
            {
                // Not a shot, no additional behaviour to be done
                return;
            }

            Destroy(gameObject);
        }
    }
}