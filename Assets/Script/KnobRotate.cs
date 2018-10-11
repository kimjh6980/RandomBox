using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobRotate : MonoBehaviour {

    public GameObject[] Mode1Canvas = new GameObject[10];
    private GameObject M1_TP;

    private Animator BusDoorAni;
    private Transform KnobBody;
    Vector3 KnobPos;

    public Renderer rend;

    // Use this for initialization
    void Start () {
        
        BusDoorAni = GameObject.Find("BusAddInner").GetComponent<Animator>();
        KnobBody = GameObject.Find("KnobBody").transform;

        M1_TP = GameObject.Find("M1_TP");
        M1_TP.SetActive(false);

        rend = GameObject.Find("KnobValue").GetComponent<Renderer>();

        this.enabled = false;
    }

    public void Mode1Start()
    {
        this.enabled = true;
        Mode1Canvas[0].SetActive(true);
        //KnobPos.y = -120;
        KnobBody.Rotate(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update () {
	}
}
