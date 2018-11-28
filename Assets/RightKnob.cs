using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightKnob : MonoBehaviour {

    private Transform tr;
    public Animation sw;
    public Animation dor;
    public static bool dor2;
    public GameObject Guide1;
    public GameObject Guide2;
    public GameObject TPCube1;
    public GameObject TPCube2;

    // Use this for initialization
    void Start()
    {
        tr = GameObject.Find("Switch").GetComponent<Transform>();
        dor2 = false;
        //Guide2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("Switch"))
        {
            sw.Play();
            dor2 = true;
        }

        if(other.name.Equals("Door"))
        {
            if(dor2)
            {
                Guide1.SetActive(false);
                dor.Play("ssd");
                Guide2.SetActive(true);
                TPCube1.SetActive(false);
                TPCube2.SetActive(true);
            }
            else
            {
                dor.Play("tick");
            }
        }
    }
}
