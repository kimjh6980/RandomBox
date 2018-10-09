using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColliderEvent : MonoBehaviour {

	public GameObject[] ring = new GameObject[10];
    private Animator BusDoorAni;
    private Animator BusAni;

    private void Awake()
    {
        BusDoorAni = GameObject.Find("BusAddInner").GetComponent<Animator>();
        BusAni = GameObject.Find("Player&Bus").GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("TP_Ring"))
        {
            
            switch(other.name)
            {
                case "R1":
                    Debug.Log("TP_Ring R1");
                    ring[0].SetActive(false);
                    BusDoorAni.SetInteger("StatusNum", 2);
                    BusAni.SetInteger("BusRun", 1);
                    //ring[1].SetActive(true);
                    break;
            }
        }
    }
}
