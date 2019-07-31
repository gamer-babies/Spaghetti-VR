using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Prefabs.MessageSystem
{
    public class EventInformation
    {
        [Tooltip("Object which triggered the event")]
        public GameObject triggerObject;

        [Tooltip("Object which triggered the event")]
        public MonoBehaviour triggerScript;

        public EventInformation(GameObject triggerObject, MonoBehaviour triggerScript)
        {
            this.triggerObject = triggerObject;
            this.triggerScript = triggerScript;
        }
    }
}
