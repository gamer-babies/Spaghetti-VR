using MessageSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Targets
{
    public class TrainingDollBehavior : MonoBehaviour
    {
        [Tooltip("Maximum lifetime in seconds. <= 0 means there is no lifetime")]
        public float lifetime;

        EventManager eventManager;

        void Start()
        {
            eventManager = EventManager.instance;
            if (lifetime > 0)
            {
                Destroy(gameObject, lifetime);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            var ammunitionInformation = collision.gameObject.GetComponent<Ammunition.AmmunitionInformation>();
            if (ammunitionInformation == null)
            {
                // Not a shot, no additional behaviour to be done
                return;
            }

            Destroy(gameObject);
            
            EventManager.TriggerEvent(MessageSystem.EventType.TargetHit, new Assets.Prefabs.MessageSystem.EventInformation(gameObject, this));
        }
    }
}