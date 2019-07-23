using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace Weapons
{
    [RequireComponent(typeof(Interactable))]
    [RequireComponent(typeof(Rigidbody))]
    public class PistolBehavior : MonoBehaviour
    {
        public SteamVR_Action_Boolean triggerAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Trigger");

        [EnumFlags]
        [Tooltip("The flags used to attach this object to the hand.")]
        public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic;

        [Tooltip("The local point which acts as a positional and rotational offset to use while held")]
        public Transform attachmentOffset;


        public GameObject shotPrefab;

        public GameObject shotSpawnLocation;

        protected new Rigidbody rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        protected virtual void HandHoverUpdate(Hand hand)
        {
            GrabTypes startingGrabType = hand.GetGrabStarting();

            if (startingGrabType != GrabTypes.None)
            {
                hand.AttachObject(gameObject, startingGrabType, attachmentFlags, attachmentOffset);
                hand.HideGrabHint();
            }
        }

        protected virtual void HandAttachedUpdate(Hand hand)
        {
            if (triggerAction.GetStateDown(hand.handType))
            {
                var shot = Instantiate(shotPrefab, shotSpawnLocation.transform);
                shot.transform.parent = null;
                shot.GetComponent<Rigidbody>().velocity = shotSpawnLocation.transform.TransformDirection(new Vector3(0, 0, 1f));
                //shot.transform.position = shotSpawnLocation.transform.position;
                //shot.transform.rotation = shotSpawnLocation.transform.rotation;
                //shot.velocity = shotSpawnLocation.transform.TransformDirection(new Vector3(0, 0, 1f));
            }
        }
    }

}