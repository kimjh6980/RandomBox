using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EachHit / col = " + other.name);
        if (other.name.Equals("HandHammer"))
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<BreakableWindow>().breakWindow();
        }
    }

}

