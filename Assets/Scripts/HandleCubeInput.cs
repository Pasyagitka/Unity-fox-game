using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCubeInput : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    void Start()
    {
    }

    void FixedUpdate()
    {
         if (Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log(hit.transform.gameObject);
                if (hit.transform.gameObject.TryGetComponent(out ThrowByMouse throwByMouse))
                {
                    Debug.Log("tut");
                    throwByMouse.Throw(hit.distance);
                }
            }
         }
    }
}
