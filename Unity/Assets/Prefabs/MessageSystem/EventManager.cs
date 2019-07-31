using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets.Prefabs.MessageSystem;

namespace MessageSystem
{
    public class EventManager : MonoBehaviour
    {
        private Dictionary<EventType, Action<EventInformation>> eventDictionary;

        private static EventManager eventManager;

        public static EventManager instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                    if (!eventManager)
                    {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    }
                    else
                    {
                        eventManager.Init();
                    }
                }

                return eventManager;
            }
        }

        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<EventType, Action<EventInformation>>();
            }
        }

        public static void StartListening(EventType eventType, Action<EventInformation> listener)
        {

            Action<EventInformation> thisEvent;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent += listener;
            }
            else
            {
                thisEvent += listener;
                instance.eventDictionary.Add(eventType, thisEvent);
            }
        }

        public static void StopListening(EventType eventType, Action<EventInformation> listener)
        {
            if (eventManager == null) return;
            Action<EventInformation> thisEvent;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent -= listener;
            }
        }

        public static void TriggerEvent(EventType eventType, EventInformation h)
        {
            Action<EventInformation> thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.Invoke(h);
            }
        }
    }
}