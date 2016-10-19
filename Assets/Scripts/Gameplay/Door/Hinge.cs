using UnityEngine;
using System.Collections;

//this is the hinge component of the chisel & hammer mechanics
public class Hinge : MonoBehaviour
{
    public GameObject DoorHinge;

    private bool ChiselInside = false;

    void OnTriggerEnter()
    {
        ChiselInside = true;
    }

    void OnTriggerStay()
    {
        ChiselInside = true;
    }

    void OnTriggerExit()
    {
        ChiselInside = false;
    }

	public bool getChiselStatus()
    {
        return ChiselInside;
    }
}
