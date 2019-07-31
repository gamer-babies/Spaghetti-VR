using Assets.Prefabs.MessageSystem;
using MessageSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Information
{
    [RequireComponent(typeof(TextMesh))]
    public class ScoreKeeper : MonoBehaviour
    {
        private TextMesh textMesh;
        private int points = 0;

        // Start is called before the first frame update
        void Start()
        {
            textMesh = GetComponent<TextMesh>();
            textMesh.text = 0 + "";
            EventManager.StartListening(MessageSystem.EventType.TargetHit, TargetHit);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void TargetHit(EventInformation eventInformation)
        {
            points++;
            textMesh.text = points + "";
        }
    }
}