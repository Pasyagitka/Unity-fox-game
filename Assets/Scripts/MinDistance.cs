using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinDistance : MonoBehaviour
{
    GameObject[] targets;
    float dist;
    public static float distance = Mathf.Infinity;


    void Start()
    {
        
    }

    void Update()
    {

        targets = GameObject.FindGameObjectsWithTag("Rabbit");

        if (targets != null)
        {
            distance = Mathf.Infinity;
            foreach (GameObject target in targets)
            {
                dist = Vector3.Distance(target.transform.position, transform.position);
                if (dist < distance) {
                    distance = dist;
                }
            }
        }
    }
}
