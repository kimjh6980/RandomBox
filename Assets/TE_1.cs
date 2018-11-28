using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TE_1 : MonoBehaviour
{
    public GameObject Guide;

    private void Awake()
    {
        Guide.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("Cube"))
        {
            Guide.SetActive(true);
            Debug.Log("E1_O");
        }
        
    }
}
