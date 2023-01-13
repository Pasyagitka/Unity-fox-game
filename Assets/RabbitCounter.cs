using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitCounter : MonoBehaviour
{
    public Text t1;

    void Start () 
    {
        t1 = GetComponent<Text> ();
    }
    
    void Update () 
    {
        t1.text = "Rabbits count: " + Attack.rabbitsCount + ", closest in : " + MinDistance.distance;
    }
}
