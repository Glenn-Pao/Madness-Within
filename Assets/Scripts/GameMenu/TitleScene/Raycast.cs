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
            if (lookingObject = hit.collider.gameObject)
            {
                // You look any object.
                if (lookingObject.tag == "Button")
                {
                    // You look any button.
                    Button button = lookingObject.GetComponent<Button>();
                    button.Appeal();
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Push");
                        button.Push();
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            FadeManager.instance.Wink(0.2f);
        }
    }
}
