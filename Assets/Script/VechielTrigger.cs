using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VechielTrigger : MonoBehaviour {

    public GameObject[] CanvasList = new GameObject[10];
    public GameObject[] EventCube = new GameObject[10];
    public GameObject[] Particle = new GameObject[10];

    private Animator BusAni;
    private void Awake()
    {
        BusAni = GameObject.Find("BusAddInner").GetComponent<Animator>();
    }

    private void Start()
    {
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
                    CanvasList[1].SetActive(false);
                    CanvasList[2].SetActive(true);
                    EventCube[1].SetActive(false);
                    break;
            }
        }
    }
}
