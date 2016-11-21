using UnityEngine;
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

    // Update is called once per frame
    void Update()
    {
        /*raycasted = Physics.Raycast(raycast, out Rayhit, 0.15f);
        raycast.origin = this.transform.position;
        raycast.direction = this.transform.rotation * new Vector3(0, 0, 1);

        if (raycasted)
        {
            GO_TouchedObject = Rayhit.transform.gameObject;
        }//*/
    }

    void LateUpdate()
    {
        b_isTouching = false;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject != null && !b_isTouching)
        {
            b_isTouching = true;
            GO_TouchedObject = collider.gameObject;
        }
        else if (collider.gameObject != null && collider.gameObject.GetComponent<PointerUIReceiver>() != null)
        {
            if (b_isTouching && GO_TouchedObject != null)
            {
                if (GO_TouchedObject.GetComponent<PointerUIReceiver>() != null)
                {
                    GO_TouchedObject.GetComponent<PointerUIReceiver>().setTrigger(false);
                    GO_TouchedObject.GetComponent<PointerUIReceiver>().setTouchpad(false);
                }
            }

            b_isTouching = true;
            GO_TouchedObject = collider.gameObject;
        }
    }
    /*
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject != null && !b_isTouching)
        {
            b_isTouching = true;
            GO_TouchedObject = collider.gameObject;
            TriggerCount += 1;
        }
        else if (collider.gameObject != null && collider.gameObject.GetComponent<PointerUIReceiver>() != null)
        {
            b_isTouching = true;
            GO_TouchedObject = collider.gameObject;
            
        }//
        //b_isTouching = true;

        TriggerCount += 1;
        
    }//*/
    /*
    private void OnTriggerExit(Collider collider)
    {
        TriggerCount -= 1;

        if (TriggerCount <= 0)
        {
            b_isTouching = false;
            TriggerCount = 0;
        }
    }//*/
}
