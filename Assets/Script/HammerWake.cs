using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerWake : MonoBehaviour {

    public bool HammerStatus = false;
    public GameObject M2_1;
    private GameObject HandHammer;
    private GameObject HammerList;

	// Use this for initialization
	void Start () {
        HandHammer = GameObject.Find("HandHammer");
        HammerList = GameObject.Find("HammerList");
        HandHammer.SetActive(false);
    }
	
    public void Wake()
    {
        M2_1.SetActive(false);
        HammerList.SetActive(false);
        HandHammer.SetActive(true);
        //GameObject.Find("Window1").GetComponent<BoxCollider>().enabled = true;
    }

    public void Canvas1UP()
    {
        M2_1.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
