using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ammunition
{
    [RequireComponent(typeof(AudioSource))]
    public class PistolShotBehavior : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<AudioSource>().Play();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
