using UnityEngine;
using System.Collections;

public class ControllerRenderer : MonoBehaviour
{
    bool b_hasWorked = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!b_hasWorked)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if (this.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                {
                    this.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                    b_hasWorked = true;
                }
            }
        }
        else
        {
            GameObject.Destroy(this.GetComponent<ControllerRenderer>());
        }
    }
}
