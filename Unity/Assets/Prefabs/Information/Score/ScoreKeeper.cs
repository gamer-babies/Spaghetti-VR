using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Information
{
    [RequireComponent(typeof(TextMesh))]
    public class ScoreKeeper : MonoBehaviour
    {
        private TextMesh textMesh;

        // Start is called before the first frame update
        void Start()
        {
            textMesh = GetComponent<TextMesh>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}