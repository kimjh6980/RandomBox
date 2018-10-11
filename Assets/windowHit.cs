using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowHit : MonoBehaviour {

    public GameObject[] windowlist = new GameObject[10];

    private int windowCount = -1;
    
	// Use this for initialization
	void Start () {
        for(int i=0; i<windowlist.Length; i++)
        {
            windowlist[i].SetActive(false);
        }
        windowlist[0].SetActive(true);
	}
	
	public void WindowBreak()
    {
        windowCount++;
        windowlist[windowCount].SetActive(false);
        windowlist[windowCount+1].SetActive(true);
    }
}
