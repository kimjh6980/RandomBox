using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raaaaay : MonoBehaviour {

    private Transform tr;
    public Animation sw;
    public Animation dor;
    public static bool dor2;
	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
        dor2 = false;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 1.5f, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.name == "Switch")
                {
                    sw.Play();
                    dor2 = true;
                }

                else if (hit.collider.name == "Door" && dor2 == true)
                {
                    dor.Play("ssd");
                }

                else if (hit.collider.name == "Door" && dor2 == false)
                {
                    dor.Play("tick");
                }

            }

        }
	}
}
