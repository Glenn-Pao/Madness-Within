using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{
    public GameObject lookingObject;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider != null)
            {
                if (lookingObject = hit.collider.gameObject)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Push");
                        if (lookingObject.tag == "Button")
                            lookingObject.GetComponent<Button>().pushedButton();
                    }
                }

            }
        }

        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //if (Physics.Raycast(transform.position, fwd, 10)) ;



    }
}
