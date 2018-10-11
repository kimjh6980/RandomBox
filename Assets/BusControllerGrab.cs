using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusControllerGrab : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    // 1
    private GameObject collidingObject;
    // 2
    private GameObject objectInHand;

    private GameObject KnobBody;
    private bool KnobStatus = false;
    private float RControllerYvalue = 0;

    public float FinY = 240.0f;
    public float damp = 0.1f;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        KnobBody = GameObject.Find("KnobBody");
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
        Debug.Log("Bus Collider Object name = " + col.name);

        
    }
    // 1
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
    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

        if (objectInHand.name == "KnobBody")
        {
            RControllerYvalue = this.transform.eulerAngles.y;
            KnobStatus = true;
        }
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity =

           Controller.angularVelocity;
        }
        // 4

        if(objectInHand.name == "KnobBody")
        {
            KnobStatus = false;
        }
        objectInHand = null;
    }

    private static Vector3 Finrotate = new Vector3(0, 240, 0).normalized;
    Quaternion ToFin = Quaternion.LookRotation(Finrotate);
    //(Quternion -> 0/0.8660254/0/-0.5)-----------------------------------

    // Update is called once per frame
    void Update()
    {
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        // 2
        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }

        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            if (this.GetComponent<HammerWake>().HammerStatus)
            {
                if (collidingObject)
                {
                    Debug.Log("Grip = " + collidingObject.name);
                    if (collidingObject.name.Equals("Hammer"))
                    {
                        Debug.Log("Hammer");
                        this.GetComponent<HammerWake>().Wake();
                        this.GetComponent<SphereCollider>().enabled = false;
                        //GameObject.Find("Controller(right)/Model").SetActive(false);
                    }
                }
            }
        }
        if(objectInHand != null)
        {
            if (objectInHand.name == "KnobBody")
            {
                objectInHand.transform.localRotation = Quaternion.Slerp(transform.rotation, ToFin, Time.deltaTime * damp);
                //Debug.Log("Obj - YV = " + YValue);
            }
        }

        if(Input.GetKey("a"))   {//----------------------------------------------------------------------------------a
            GameObject KnobKey = GameObject.Find("KnobBody");
            KnobKey.transform.localRotation = Quaternion.Slerp(transform.localRotation, ToFin, Time.deltaTime * damp);
        }

        if(Input.GetKey("w"))   //-----------------------------------------------------------------------------------w
        {
            GameObject KnobKey = GameObject.Find("KnobBody");
            Debug.Log("W = " + KnobKey.transform.localRotation.x + "/" + KnobKey.transform.localRotation.y + "/" + KnobKey.transform.localRotation.z + "/" + KnobKey.transform.localRotation.w);
        }
        
    }
}