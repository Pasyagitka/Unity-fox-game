using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowByMouse : MonoBehaviour
{
    Rigidbody rb;
    float moveForce = 0.9f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Throw(float distance) {
        rb.AddForce(Vector3.forward * distance * moveForce, ForceMode.Impulse);
    }
}
