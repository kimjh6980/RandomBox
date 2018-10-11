using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobRotate : MonoBehaviour {

    public GameObject[] Mode1Canvas = new GameObject[10];
    public GameObject M1_ResultTP;

    private Animator BusDoorAni;
    private Transform KnobBody;
    Vector3 KnobPos;

    public Renderer rend;

    // Use this for initialization
    void Start () {
        
        BusDoorAni = GameObject.Find("BusAddInner").GetComponent<Animator>();
        KnobBody = GameObject.Find("KnobBody").transform;
        

        rend = GameObject.Find("KnobValue").GetComponent<Renderer>();

        this.enabled = false;
    }

    public void Mode1Start()
    {
        this.enabled = true;
        Mode1Canvas[0].SetActive(true);
        //KnobPos.y = -120;
        KnobBody.Rotate(new Vector3(0, -120, 0));
    }

    // Update is called once per frame
    void Update () {
        // -120 = -0.8660254 & 120 = 0.8660254
        float YValue = KnobBody.localRotation.y;
        Debug.Log("YVale = " + YValue);
        //rend.material.SetTextureOffset("_MainTex", new Vector2(YValue/480, 0));
        if (YValue <-0.8660254)
        {
            KnobBody.Rotate(new Vector3(0, -120, 0));
        }   else if (YValue>=0.8660254)
        {
            BusDoorAni.SetInteger("StatusNum", 3);
            Mode1Canvas[0].SetActive(false);
            M1_ResultTP.SetActive(true);
            Mode1Canvas[1].SetActive(true);
            
        }
	}
}
