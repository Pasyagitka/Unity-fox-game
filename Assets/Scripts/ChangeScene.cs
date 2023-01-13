using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    { 
        print("Detected collision between " + gameObject.name + " and " + other.collider.name);

        if (other.gameObject.tag == "Arch") {
            SceneManager.LoadScene("SecondScene", LoadSceneMode.Single);
        }
    }
}

