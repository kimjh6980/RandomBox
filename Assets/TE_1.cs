using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TE_1 : MonoBehaviour
{
    public GameObject Guide;
    public GameObject Fire;
    public GameObject CB;

    private void Awake()
    {
        Guide.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("subway Collider = " + other.name);
        if(other.name.Equals("Cube"))
        {
            CB.SetActive(true);
            Guide.SetActive(true);
            Fire.SetActive(true);
            Debug.Log("E1_O");
        }
    }
}
