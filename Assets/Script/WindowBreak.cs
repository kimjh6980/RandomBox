using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{
    public GameObject RightHammer;
    public GameObject M2_2;
    public GameObject M2_TP;
    public GameObject M2_3;

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
            RightHammer.SetActive(false);
        }
    }

}

