using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle : MonoBehaviour {

    public Animation sw;
    public Animation dor;
    public Animation exit;
    public static bool dor2 = false;

    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;
    // 2
    private GameObject objectInHand;

    public GameObject Canvas2;

    public GameObject sd;
    public GameObject gd;
    
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    void Update() 
    {
        if (Controller.GetAxis() != Vector2.zero)
        {
            Debug.Log(gameObject.name + Controller.GetAxis());
        }

        // 2
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + " Trigger Press");

            if(collidingObject != null)
            {
                if (collidingObject.name.Equals("Switch"))
                {
                    sw.Play();
                    dor2 = true;

                }

                if (collidingObject.name.Equals("GlassDoor"))
                {
                    gd.GetComponent<AudioSource>().Play();
                    exit.Play();
                }

                if (collidingObject.name.Equals("Door"))
                {
                    if (dor2)
                    {
                        Canvas2.SetActive(true);
                        dor.Play("ssd");
                        sd.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        dor.Play("tick");
                    }
                }
            }
            
            
        }

        // 3
        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + " Trigger Release");
        }

        // 4
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Press");
        }

        // 5
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Release");
        }
 
    }
    /*
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
                dor.Play("ssd");
            }
            else
            {
                dor.Play("tick");
            }
        }
    }
     */
}
