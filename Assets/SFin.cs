using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFin : MonoBehaviour {

    public GameObject Right;
    public GameObject FinCanvas;
    public GameObject Head;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("ColliderBody"))
        {
            Right.GetComponent<LaserPointer>().enabled = true;
            FinCanvas.SetActive(true);
            Head.GetComponent<AudioSource>().Play();
        }
    }
}
