using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEachHit : MonoBehaviour {
    private bool CollisionDelay = false;
    private GameObject windowMain;

    private float NextTime = 2f;
    private float TimeCount = 0;

    private void WindowBreak()
    {
        Debug.Log("WindowBreak");
        windowMain.GetComponent<windowHit>().WindowBreak();
    }

    void Start()
    {
        windowMain = GameObject.Find("Window");
    }
    
    private void Update()
    {
        if(CollisionDelay)
        {
            TimeCount += Time.deltaTime;
            if(TimeCount >= NextTime)
            {
                CollisionDelay = false;
                TimeCount = 0;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EachHit / col = " + other.name);
        
            if (other.name.Equals("HandHammer"))
            {
                if (CollisionDelay == false) {
                    CollisionDelay = true;
                    Invoke("WindowBreak", 0.3f);
                    //WindowBreak();
                }
            }
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("HandHammer"))
        {
            if (CollisionDelay)
            {
                Debug.Log("WindowEachHit - TriggerExit");
                CollisionDelay = false;
            }
        }
    }
    */
}
