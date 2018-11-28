using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour {

    public GameObject GD1;
    public GameObject GD2;

    public GameObject G1;
    public GameObject G2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("T_E2"))
        {
            this.gameObject.SetActive(false);
            GD1.GetComponent<Animation>().Play("tick");
            GD2.GetComponent<Animation>().Play("tick");
            G1.SetActive(false);
            G2.SetActive(true);
        }
    }
}
