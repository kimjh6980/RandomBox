using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColliderEvent : MonoBehaviour {

	public GameObject[] ring = new GameObject[10];
    public GameObject RightController;
    private Animator BusDoorAni;
    private Animator BusAni;
    private GameObject FinishCanvas;

    private void Awake()
    {
        BusDoorAni = GameObject.Find("BusAddInner").GetComponent<Animator>();
        BusAni = GameObject.Find("Player&Bus").GetComponent<Animator>();
        FinishCanvas = GameObject.Find("FinishCanvas");
        FinishCanvas.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
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
                case "R2":
                    FinishCanvas.SetActive(true);
                    RightController.GetComponent<LaserPointer>().enabled = true;
                    break;
            }

        }
    }
}
