﻿using UnityEngine;
using System.Collections;

public class AuraViveInteractCollider : MonoBehaviour
{
    public bool b_isTouching = false;
    public GameObject GO_TouchedObject;

    int TriggerCount = 0;

    bool raycasted;
    Ray raycast;
    RaycastHit Rayhit;

    // Use this for initialization
    void Start()
    {

    }

    void LateUpdate()
    {
        if (TriggerCount <= 0)
        {
            b_isTouching = false;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        /*if (collider.gameObject != null && !b_isTouching)
        {
            b_isTouching = true;
            GO_TouchedObject = collider.gameObject;
        }//*/
        if (collider.gameObject != null && collider.gameObject.GetComponent<PointerUIReceiver>() != null)
        {
            /*if (b_isTouching && GO_TouchedObject != null)
            {
                if (GO_TouchedObject.GetComponent<PointerUIReceiver>() != null)
                {
                    GO_TouchedObject.GetComponent<PointerUIReceiver>().setTrigger(false);
                    GO_TouchedObject.GetComponent<PointerUIReceiver>().setTouchpad(false);
                }
            }//*/

            b_isTouching = true;
            GO_TouchedObject = collider.gameObject;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject != null && collider.gameObject.GetComponent<PointerUIReceiver>() != null)
        {
            TriggerCount += 1;
        }
    }//*/

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject != null && collider.gameObject.GetComponent<PointerUIReceiver>() != null)
        {
            TriggerCount -= 1;

            if (TriggerCount <= 0)
            {
                TriggerCount = 0;
            }
        }
    }//*/
}
