using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobRotate : MonoBehaviour {

    private Animator BusDoorAni;
    private Transform KnobBody;
    Vector3 KnobPos;

    public Renderer rend;

    // Use this for initialization
    void Start () {
        BusDoorAni = GameObject.Find("BusAddInner").GetComponent<Animator>();
        KnobBody = GameObject.Find("KnobBody").transform;
        KnobPos.y = -120;

        rend = GameObject.Find("KnobValue").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update () {
        float YValue = KnobPos.y + 120;
        rend.material.SetTextureOffset("_MainTex", new Vector2(YValue/120, 0));
        if (KnobPos.y<-120)
        {
            KnobPos.y = -120;
        }   else if (KnobPos.y>=120)
        {
            BusDoorAni.SetInteger("StatusNum", 3);
        }
	}
}
