using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{
    private GameObject M2_2;
    private GameObject M2_TP;
    private GameObject M2_3;

    private void Start()
    {
        M2_2 = GameObject.Find("M2_2");
        M2_2.SetActive(false);
        M2_TP = GameObject.Find("M2_TP");
        M2_TP.SetActive(false);

        M2_3 = GameObject.Find("M2_3");
        M2_3.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EachHit / col = " + other.name);
        if (other.name.Equals("HandHammer"))
        {
            M2_2.SetActive(false);
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<BreakableWindow>().breakWindow();
            M2_TP.SetActive(true);
            M2_3.SetActive(true);
        }
    }

}

