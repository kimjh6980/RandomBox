using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VechielTrigger : MonoBehaviour {

    public GameObject[] CanvasList = new GameObject[3];
    public GameObject[] EventCube = new GameObject[2];
    public GameObject[] Particle = new GameObject[2];

    public GameObject RightController;

    private Animator BusAni;

    public GameObject Bus;
    private AudioSource bs;

    public GameObject Bd;
    private AudioSource ds;

    public GameObject[] flame = new GameObject[10];
    public GameObject[] brust = new GameObject[4];

    private void Awake()
    {
        BusAni = GameObject.Find("BusAddInner").GetComponent<Animator>();
    }

    private void Start()
    {
        bs = Bus.GetComponent<AudioSource>();
        ds = Bd.GetComponent<AudioSource>();

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
                    bs.Pause();
                    ds.Play();
                    break;
                case "E1":
                    Debug.Log("E1");
                    Particle[0].SetActive(false);
                    CanvasList[1].SetActive(false);
                    CanvasList[2].SetActive(true);
                    EventCube[1].SetActive(false);
                    Particle[1].SetActive(true);
                    RightController.GetComponent<LaserPointer>().enabled = true;

                    for(int i=0; i<flame.Length; i++)
                    {
                        flame[i].GetComponent<AudioSource>().Play();
                    }
                    for (int i = 0; i < brust.Length; i++)
                    {
                        brust[i].GetComponent<AudioSource>().Play();
                    }
                    bs.Stop();
                    break;
            }
        }
    }
}
