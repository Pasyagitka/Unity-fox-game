using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public static int rabbitsCount = 0;

    void OnCollisionEnter(Collision myCollision) 
    {
        print("Detected collision between " + gameObject.name + " and " + myCollision.collider.name);
        if (myCollision.gameObject.tag == "Rabbit") {
            rabbitsCount++;
            Destroy(myCollision.gameObject, 0.1f);
        }
        Debug.Log(rabbitsCount);
    }
}
