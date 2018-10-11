using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerGrabObject : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    // 1
    private GameObject collidingObject;
    // 2
    private GameObject objectInHand;

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
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }


    private void RightControllerCollider(GameObject col)
    {

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
        objectInHand = null;
    }

    private void ChangeGameScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    // Update is called once per frame
    void Update () {
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                if(collidingObject.CompareTag("SceneChangeT"))
                {
                    Debug.Log("SceneChangeT = " + collidingObject.name);
                    ChangeGameScene(collidingObject.name);
                }
                else
                {
                    GrabObject();
                }
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
            if(this.GetComponent<HammerWake>().HammerStatus)
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
    }
}
