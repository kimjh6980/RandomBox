using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VechielTrigger : MonoBehaviour {

    public GameObject[] CanvasList = new GameObject[3];
    public GameObject[] EventCube = new GameObject[2];
    public GameObject[] Particle = new GameObject[2];

    public GameObject RightController;

    private Animator BusAni;
    private void Awake()
    {
        BusAni = GameObject.Find("BusAddInner").GetComponent<Animator>();
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            CanvasList[i].SetActive(false);
        }
        for (int i=0; i<2; i++)
        {
            Particle[i].SetActive(false);
        }
        RightController.GetComponent<LaserPointer>().enabled = false;
        CanvasList[0].SetActive(true);
        BusAni.SetInteger("StatusNum", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EventTag"))
        {
            switch (other.name)
            {
                case "E0":
                    CanvasList[0].SetActive(false);
                    CanvasList[1].SetActive(true);
                    EventCube[0].SetActive(false);
                    Particle[0].SetActive(true);
                    break;
                case "E1":
                    Debug.Log("E1");
                    Particle[0].SetActive(false);
                    CanvasList[1].SetActive(false);
                    CanvasList[2].SetActive(true);
                    EventCube[1].SetActive(false);
                    Particle[1].SetActive(true);
                    RightController.GetComponent<LaserPointer>().enabled = true;
                    break;
            }
        }
    }
}
