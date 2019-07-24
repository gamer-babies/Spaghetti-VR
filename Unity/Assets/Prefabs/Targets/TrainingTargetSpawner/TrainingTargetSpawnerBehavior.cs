using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrainingTargetSpawnerBehavior : MonoBehaviour
{
    public GameObject targetPrefab;

    private DateTime lastTargetSpawn;
    private System.Random rand;

    // Start is called before the first frame update
    void Start()
    {
        lastTargetSpawn = DateTime.Now;
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now > lastTargetSpawn + TimeSpan.FromSeconds(1))
        {
            lastTargetSpawn = DateTime.Now;

            var target = Instantiate(targetPrefab, transform);
            target.transform.parent = null;
            target.GetComponent<Rigidbody>().velocity = new Vector3((float)rand.NextDouble() * 10f - 5f, (float)rand.NextDouble() * 10f - 5f, 0);
        }
    }
}
