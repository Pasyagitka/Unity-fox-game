using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensivity;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private bool lookAt = true;


    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       Rotate(); 
       Attach();
    }

    private void Rotate() 
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;

        target.Rotate(Vector3.up, mouseX);
    }

    public void Attach()
    {
        // compute position
        transform.position = target.TransformPoint(offsetPosition);
  
        if(lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            //transform.rotation = target.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime);
        }
    }
}
