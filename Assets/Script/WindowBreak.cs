using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{
    private GameObject M2_TP;

    private void Start()
    {
        M2_TP = GameObject.Find("M2_TP");
        M2_TP.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EachHit / col = " + other.name);
        if (other.name.Equals("HandHammer"))
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<BreakableWindow>().breakWindow();
            M2_TP.SetActive(true);

        }
    }

}

