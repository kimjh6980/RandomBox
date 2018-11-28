using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ani : MonoBehaviour {

    public Animation tr;
    public Animation per;
    public Animation sw;

	// Use this for initialization
	void Start () {

        tr.Play("movetrain");
        per.Play("movechar");
        sw.Play("movesw2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
